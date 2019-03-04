using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace opfa_common_managed
{
    /*[StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class LinkNode : Node
    {
        //public members
        internal byte resistance = 0;
        internal Dictionary<LinkNode, byte> links = new Dictionary<LinkNode, byte>();

        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        internal LinkNode(byte resistance)
        {
            this.resistance = resistance;
        }
        /// <summary>
        /// Construtor with custom H-Cost for target nodes.
        /// </summary>
        /// <param name="customHCost">The custom H-Cost.</param>
        internal LinkNode(byte resistance, uint customHCost)
        {
            this.resistance = resistance;
            this.hCost = customHCost;
        }
        /// <summary>
        /// Construtor for starting nodes.
        /// </summary>
        /// <param name="linkMemory">The memory to calculate H-Cost from.</param>
        internal LinkNode(byte resistance, LinkMemory linkMemory)
        {
            this.resistance = resistance;
            gCost = 0;
            hCost = CalculateHeuristic(linkMemory.targetNode);
            fCost = hCost;
        }
        #endregion

        #region Heuristic
        internal uint CalculateHeuristic(linkMemory)
        {
            return linkMemory.ToTarget * 10;
        }
        #endregion
        internal void BakeLinks(byte[] links)
        {
            foreach (byte resistance in links)
            {
                //handshake between links
                LinkNode adjecent = new LinkNode(resistance);
                this.links.Add(adjecent, adjecent.resistance);
                adjecent.links.Add(this, resistance);
            }
        }
    }*/
}
