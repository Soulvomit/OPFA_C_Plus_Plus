using System.Collections.Generic;

namespace opfa_common_managed
{
    internal class CubicOpenComparer : IComparer<CubicNode>
    {
        public int Compare(CubicNode left, CubicNode right)
        {
            int comparison = left.fCost.CompareTo(right.fCost);
            if (comparison == 0)
            {
                comparison = left.hCost.CompareTo(right.hCost);
            }
            return comparison;
        }
    }
}
