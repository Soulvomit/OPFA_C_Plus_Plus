using System.Collections.Generic;
using System.Threading;

namespace opfa_common_managed
{
    internal abstract class Pathfinder<T, V>
    {
        //protected members
        protected Memory<T, V> memory;
        protected PriorityQueue<T> openQueue;
        protected Dictionary<V, T> creationMap;
        protected HashSet<V> closedSet;
        protected readonly object outbufferLock = new object();
        protected volatile bool producingFrame = false;
        //properties
        public Memory<T, V> BaseMemory { get { return memory; } }
        public Layout BaseLayout { get { return memory.Layout; } }
        public bool IsProducingFrame { get { return producingFrame; } }

        protected Pathfinder(Memory<T, V> memory)
        {
            //memory-pathfinder hand shake
            memory.pathfinder = this;
            this.memory = memory;
        }

        internal abstract void ProduceFrame();

        #region Runnable Task
        internal void RunnableTask()
        {
            while (!memory.IsStopped && !memory.IsPaused)
            {
                //frame producer
                ProduceFrame();
                //if stopped
                if (memory.IsStopped)
                {
                    //break frame production
                    break;
                }
                else if (memory.IsYielding)
                {
                    //yeild frame production
                    #if v35
                    Thread.Sleep(0);    //.Net 3.5
                    #else
                    Thread.Yield();     //above .Net 3.5
                    #endif
                }
            }
            //if paused enter spin lock
            while (memory.IsPaused)
            {
                //if stopped
                if (memory.IsStopped)
                {
                    //break spin lock
                    break;
                }
                //if yield
                else if (memory.IsYielding)
                {
                    //yield spin lock
                    #if v35
                    Thread.Sleep(1);    //.Net 3.5
                    #else
                    Thread.Yield();     //above .Net 3.5
                    #endif
                }
                //else, dirty busy-waiting spin lock!!
                else
                {
                    Thread.SpinWait(1);
                }
            }
        }
        #endregion
    }
}

