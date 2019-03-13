using System.Runtime.InteropServices;
using System.Threading;

namespace opfa_common_managed
{
    public abstract class Memory<T, V>
    {
        //internal members
        internal Layout layout;
        internal Thread worker = null;
        internal volatile uint outbufferSize;
        internal volatile bool yielding = true;
        internal volatile bool paused = false;
        internal volatile bool stopped = true;
        internal readonly object outbufferLock = new object();
        internal volatile bool targetChanged = false;
        internal volatile int pathLength = 0;
        internal Pathfinder<T, V> pathfinder = null;
        internal EnviromentType enviromentType = EnviromentType.Managed;

        #region Properties
        public uint OutBufferSize { get { return outbufferSize; } }
        public Layout Layout { get { return layout; } }
        public bool IsYielding { get { return yielding; } }
        public bool IsStopped { get { return stopped; } }
        public bool IsPaused { get { return paused; } }
        public bool IsRunning { get { return (worker != null); } }
        public Thread Worker { get { return worker; } }
        public int PathLength { get { return pathLength; } }
        public abstract uint[,] Path {  get; }
        public EnviromentType EnviromentType { get { return enviromentType; } set { enviromentType = value; } }
        #endregion

        #region Constructor
        protected Memory(uint outbufferSize, Layout layout)
        {
            this.outbufferSize = outbufferSize;
            this.layout = layout;
        }
        #endregion

        #region Run Once
        public void RunThreadedOnce()
        {
            if (IsRunning)
            {
                //we cant override a running tread
                throw new System.Exception("Can not override a running task. Make sure to task is stopped first.");
                //return;
            }
            worker = new Thread(pathfinder.ProduceFrame, (int)(Marshal.SizeOf(typeof(GridNode)) * outbufferSize));
            worker.Priority = ThreadPriority.Highest;
            worker.Start();
        }
        public void JoinThreadedOnce()
        {
            worker.Join();
            worker = null;
        }
        public void RunOnce()
        {
            //run once in calling thread
            pathfinder.ProduceFrame();
        }
        #endregion

        #region Run
        public void Run()
        {
            if (IsRunning)
            {
                //we cant override a running tread
                throw new System.Exception("Can not override a running task. Make sure to task is stopped first.");
                //return;
            }
            worker = new Thread(Task/*, (int)(Marshal.SizeOf(typeof(GridNode)) * layout.InBufferSize)*/);
            worker.Priority = ThreadPriority.Highest;
            worker.Start();
        }
        private void Task()
        {
            stopped = false;
            paused = false;
            while (!stopped)
            {
                pathfinder.RunnableTask();
            }
            //end task
            worker.Join();
            worker = null;
        }
        #endregion

        #region Stop/Pause/Resume/Yield
        public void Stop()
        {
            //make sure operation is atomic
            stopped = true;
        }
        public void Pause()
        {
            //make sure operation is atomic
            paused = true;
        }
        public void Resume()
        {
            //make sure operation is atomic
            paused = false;
        }
        public void Yield()
        {
            //make sure operation is atomic
            yielding = true;
        }
        public void Unyield()
        {
            //make sure operation is atomic
            yielding = false;
        }
        #endregion
    }
}
