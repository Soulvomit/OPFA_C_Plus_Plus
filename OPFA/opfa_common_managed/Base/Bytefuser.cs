namespace opfa_common_managed
{
    internal static class Bytefuser
    {
        //const private members
        private const ulong NULL_HIGH_32    =   0x00000000FFFFFFFF;
        private const ulong NULL_LOW_32     =   0xFFFFFFFF00000000;
        private const uint NULL_HIGH_16     =   0x0000FFFF;
        private const uint NULL_LOW_16      =   0xFFFF0000;

        #region Fusing Methods
        internal static ulong Fuse(ushort high, ushort high_mid, ushort low_mid,  ushort low)
        {
            uint upper = Fuse(high, high_mid);
            uint lower = Fuse(low_mid, low);
            return Fuse(upper, lower);
        }
        internal static uint Fuse(ushort high, ushort low)
	    {
            uint fusion = (((uint)high) << 16) | (uint)(low & NULL_HIGH_16);
            return fusion;
	    }
        internal static ulong Fuse(uint high, uint low)
        {
            ulong fusion = (((ulong)high) << 32) | (ulong)(low & NULL_HIGH_32);
            return fusion;
        }
        internal static void Unfuse(uint fusion, out ushort high, out ushort low)
        {
            high = (ushort)((fusion & NULL_LOW_16) >> 16);
            low = (ushort)(fusion & NULL_HIGH_16);
        }
        internal static void Unfuse(ulong fusion, out uint high, out uint low)
        {
            high = (uint)((fusion & NULL_LOW_32) >> 32);
            low = (uint)(fusion & NULL_HIGH_32);
        }
        internal static ushort UnfuseLow(uint fusion)
        {
            return (ushort)(fusion & NULL_HIGH_16);
        }
        internal static ushort UnfuseHigh(uint fusion)
        {
            return (ushort)((fusion & NULL_LOW_16) >> 16);
        }
        internal static uint UnfuseLow(ulong fusion)
        {
            return (uint)(fusion & NULL_HIGH_32);
        }
        internal static uint UnfuseHigh(ulong fusion)
        {
            return (uint)((fusion & NULL_LOW_32) >> 32);
        }
        #endregion
    }
}
