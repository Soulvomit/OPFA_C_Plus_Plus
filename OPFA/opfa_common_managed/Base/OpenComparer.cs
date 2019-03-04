using System.Collections.Generic;

namespace opfa_common_managed
{
    internal class OpenComparer<T, V> : IComparer<Node<T, V>>
    {
        public int Compare(Node<T, V> left, Node<T, V> right)
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
