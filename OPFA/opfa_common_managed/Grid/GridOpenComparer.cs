using System.Collections.Generic;

namespace opfa_common_managed
{
    internal class GridOpenComparer : IComparer<GridNode>
    {
        public int Compare(GridNode left, GridNode right)
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
