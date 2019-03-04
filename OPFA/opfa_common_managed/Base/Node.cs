using System.Runtime.InteropServices;

namespace opfa_common_managed
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class Node<T, V>
    {
        //public members
        internal uint fCost = uint.MaxValue;
        internal uint gCost = uint.MaxValue;
        internal uint hCost = uint.MaxValue;

        internal abstract uint CalculateHeuristic(Pathfinder<T, V> pathfinder);
    }
}
