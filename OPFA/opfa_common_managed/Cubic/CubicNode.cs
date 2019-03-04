using System;
using System.Runtime.InteropServices;

namespace opfa_common_managed
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CubicNode : Node<CubicNode, ulong>
    {
        //public members
        internal ushort[] xyz = new ushort[3];
        internal CubicNode parent = null;

        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        internal CubicNode(ushort x, ushort y, ushort z)
        {
            xyz[0] = x;
            xyz[1] = y;
            xyz[2] = z;
        }
        /// <summary>
        /// Construtor for target nodes.
        /// </summary>
        /// <param name="customHCost">The custom H-Cost.</param>
        internal CubicNode(ushort x, ushort y, ushort z, uint customHCost)
        {
            xyz[0] = x;
            xyz[1] = y;
            xyz[2] = z;
            this.hCost = customHCost;
        }
        /// <summary>
        /// Construtor for starting nodes.
        /// </summary>
        /// <param name="cubicPathfinder">The memory to calculate H-Cost from.</param>
        internal CubicNode(ushort x, ushort y, ushort z, CubicPathfinder cubicPathfinder)
        {
            xyz[0] = x;
            xyz[1] = y;
            xyz[2] = z;
            gCost = 0;
            hCost = CalculateHeuristic(cubicPathfinder);
            fCost = hCost;
        }
        #endregion

        #region Heuristic
        internal override uint CalculateHeuristic(Pathfinder<CubicNode, ulong> cubicPathfinder)
        {
            //3d manhattan
            return (uint)(10 * (Math.Abs(xyz[0] - (cubicPathfinder as CubicPathfinder).targetX) + 
                                Math.Abs(xyz[1] - (cubicPathfinder as CubicPathfinder).targetY) + 
                                Math.Abs(xyz[2] - (cubicPathfinder as CubicPathfinder).targetZ)));
        }
        #endregion
    }
}
