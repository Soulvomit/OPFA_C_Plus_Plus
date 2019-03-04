namespace opfa_common_managed
{
    public sealed class CubicMemory : Memory<CubicNode, ulong>
    {
        //internal members
        internal volatile ushort startX = 0;
        internal volatile ushort startY = 0;
        internal volatile ushort startZ = 0;
        internal volatile ushort targetX = 0;
        internal volatile ushort targetY = 0;
        internal volatile ushort targetZ = 0;
        internal volatile ulong[] outbuffer;

        #region Properties
        public CubicLayout CubicLayout { get { return (layout as CubicLayout); } }
        public ushort[] TargetPosition
        {
            get { return new ushort[3] { targetX, targetY, targetZ }; }
            set
            {
                targetChanged = true;
                targetX = value[0];
                targetY = value[1];
                targetZ = value[2];
            }
        }
        public ushort[] StartPosition
        {
            get { return new ushort[3] { startX, startY, startZ }; }
            set
            {
                startX = value[0];
                startY = value[1];
                startZ = value[2];
            }
        }
        public override uint[,] Path
        {
            get
            {
                uint[,] temp;
                lock (outbufferLock)
                {
                    temp = new uint[pathLength, 3];
                    uint counter = 0;
                    for (int i = pathLength - 1; i >= 0; i--)
                    {
                        uint highmid = Bytefuser.UnfuseHigh(outbuffer[counter]);
                        uint midlow = Bytefuser.UnfuseLow(outbuffer[counter]);
                        temp[i, 0] = Bytefuser.UnfuseHigh(highmid);
                        temp[i, 1] = Bytefuser.UnfuseLow(highmid);
                        temp[i, 2] = Bytefuser.UnfuseHigh(midlow);
                        counter++;
                    }
                }
                return temp;
            }
        }
        #endregion

        #region Constructor
        public CubicMemory(uint outbufferSize, CubicLayout cubicLayout) : base(outbufferSize, cubicLayout)
        {
            outbuffer = new ulong[outbufferSize];
            pathfinder = new CubicPathfinder(this);
        }
        #endregion

    }
}
