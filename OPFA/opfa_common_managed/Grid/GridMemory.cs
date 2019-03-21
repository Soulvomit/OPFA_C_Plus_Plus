namespace opfa_common_managed
{
    public sealed class GridMemory : Memory<GridNode, uint>
    {
        //internal members
        internal volatile ushort startX = 0;
        internal volatile ushort startY = 0;
        internal volatile ushort targetX = 0;
        internal volatile ushort targetY = 0;
        internal volatile uint[] outbuffer;
        internal volatile GridPathType pathType = GridPathType.Normal;
        internal volatile float diagonalModifier = 1.4f;

        #region Properties
        public GridLayout GridLayout { get { return (layout as GridLayout); } }
        public ushort[] TargetPosition
        {
            get { return new ushort[2] { targetX, targetY }; }
            set
            {
                targetChanged = true;
                targetX = value[0];
                targetY = value[1];
            }
        }
        public ushort[] StartPosition
        {
            get { return new ushort[2] { startX, startY }; }
            set
            {
                startX = value[0];
                startY = value[1];
            }
        }
        public override uint[,] Path
        {
            get
            {
                uint[,] temp;
                lock (outbufferLock)
                {
                    temp = new uint[pathLength, 2];
                    uint counter = 0;
                    for (int i = pathLength - 1; i >= 0; i--)
                    {
                        temp[i, 0] = Bytefuser.UnfuseHigh(outbuffer[counter]);
                        temp[i, 1] = Bytefuser.UnfuseLow(outbuffer[counter]);
                        counter++;
                    }
                }
                return temp;
            }
        }
        public GridPathType GridPathType { get { return pathType; } set { pathType = value; } }
        public float DiagonalModifier { get { return diagonalModifier; } set { diagonalModifier = value; } }
        #endregion

        #region Constructor
        public GridMemory(uint outbufferSize, GridLayout gridLayout) : base(outbufferSize, gridLayout)
        {
            outbuffer = new uint[outbufferSize];
            pathfinder = new GridPathfinder(this);
        }
        #endregion
    }
}
