using System;
using System.Runtime.InteropServices;

namespace opfa_common_managed
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class GridNode : Node<GridNode, uint>
    {
        //public members
        internal uint fxyParent = 0;
        internal ushort[] xy = new ushort[2];

        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        internal GridNode(ushort x, ushort y)
        {
            xy[0] = x;
            xy[1] = y;
        }
        /// <summary>
        /// Construtor with custom H-Cost for target nodes.
        /// </summary>
        /// <param name="customHCost">The custom H-Cost.</param>
        internal GridNode(ushort x, ushort y, uint customHCost)
        {
            xy[0] = x;
            xy[1] = y;
            this.hCost = customHCost;
        }
        /// <summary>
        /// Construtor for starting nodes.
        /// </summary>
        /// <param name="gridPathfinder">The memory to calculate H-Cost from.</param>
        internal GridNode(ushort x, ushort y, GridPathfinder gridPathfinder)
        {
            xy[0] = x;
            xy[1] = y;
            gCost = 0;
            hCost = CalculateHeuristic(gridPathfinder);
            fCost = hCost;
        }
        #endregion

        #region Heuristic
        internal override uint CalculateHeuristic(Pathfinder<GridNode, uint> gridPathfinder)
        {
            //diagonal distance
            uint xd = (uint)Math.Abs(xy[0] - (gridPathfinder as GridPathfinder).targetX);
            uint yd = (uint)Math.Abs(xy[1] - (gridPathfinder as GridPathfinder).targetY);
            if (xd > yd)
            {
                return (14 * yd + 10 * (xd - yd));
            }
            else
            {
                return (14 * xd + 10 * (yd - xd));
            }
            //2d manhattan
            /*return (uint)(10 * 
                            (Math.Abs(xy[0] - (gridPathfinder as GridPathfinder).targetX) + 
                            Math.Abs(xy[1] - (gridPathfinder as GridPathfinder).targetY)));*/
        }
        #endregion
    }
}
