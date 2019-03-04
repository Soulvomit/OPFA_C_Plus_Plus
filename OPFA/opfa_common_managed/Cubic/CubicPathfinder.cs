using System.Collections.Generic;
#if !v35
using System.Threading.Tasks;
#endif
namespace opfa_common_managed
{
    internal class CubicPathfinder : Pathfinder<CubicNode, ulong>
    {
        #region Static Private Members
        private static short[,] offsets = new short[26, 3] 
        { 
            //0 = z
            { 1, 1, 0 }, { 1, -1, 0 }, { -1, 1, 0 }, { -1, -1, 0 },
            //0 = y
            { 1, 0, 1 }, { 1, 0, -1 }, { -1, 0, 1 }, { -1 , 0, -1 },
            //0 = x
            { 0, 1, 1 }, { 0, 1, -1 }, { 0, -1, 1 }, { 0, -1, -1 },
            //0 = z, y
            { 1, 0, 0 }, { -1, 0, 0 },
            //0 = x, z 
            { 0, 1, 0 }, { 0 , -1, 0 }, 
            //0 = x, y
            { 0, 0, 1 }, { 0, 0, -1 },  
            //1 = x, y, z
            { 1, 1, 1 }, 
            //1 = x, y
            { 1, 1, -1 },
            //1 = x, z 
            { 1 ,-1, 1 },
            //1 = y, z 
            { -1, 1, 1 }, 
            //1 = x
            { 1, -1, -1 },
            //1 = y
            { -1, 1, -1 },
            //1 = z 
            { -1, -1, 1 },
            //none  
            { -1, -1, -1 }
        };
        private static byte offsetCount = 26;
        #endregion

        //private members        
        internal ushort targetX;
        internal ushort targetY;
        internal ushort targetZ;
        private ulong fxyzTarget;
        private ulong fxyzStart;
        //properties
        internal CubicMemory CubicMemory { get { return (memory as CubicMemory); } }
        internal CubicLayout CubicLayout { get { return (memory.Layout as CubicLayout); } }

        #region Constructor
        internal CubicPathfinder(CubicMemory cubicMemory) : base(cubicMemory)
        {
            creationMap = new Dictionary<ulong, CubicNode>();
            #if v35
            openQueue = new PriorityQueue<CubicNode>((int)memory.OutBufferSize, new CubicOpenComparer());
            #else
            openQueue = new PriorityQueue<CubicNode>((int)memory.OutBufferSize, new OpenComparer<CubicNode, ulong>());
            #endif
            closedSet = new HashSet<ulong>();
        }
        #endregion

        #region Produce Frame
        internal override void ProduceFrame()
        {
            producingFrame = true;
            ReadyNextFrame();
            //while open queue is not empty
            while (openQueue.Count > 0)
            {
                //set current fused x,y to the first in open queue
                CubicNode current = openQueue.Top;
                //if current is target
                if (current == creationMap[fxyzTarget])
                {
                    //frame done, construct path
                    producingFrame = false;
                    ConstructPath();
                    return;
                }
                //pop current from queue
                openQueue.Pop();
                //close the node
                closedSet.Add(Bytefuser.Fuse(current.xyz[0], current.xyz[1], current.xyz[2], 0));
                //foreach adjecent count
                for (int i = 0; i < offsetCount; i++)
                {
                    //calculate adjecent x,y,z
                    ushort adjecentX = (ushort)(current.xyz[0] + offsets[i, 0]);
                    ushort adjecentY = (ushort)(current.xyz[1] + offsets[i, 1]);
                    ushort adjecentZ = (ushort)(current.xyz[1] + offsets[i, 2]);
                    //fuse adjecent x,y
                    ulong fxyzAdjecent = Bytefuser.Fuse(adjecentX, adjecentY, adjecentZ, 0);
                    //if adjecent fxyz is closed
                    if (closedSet.Contains(fxyzAdjecent))
                    {
                        //node closed, continue
                        continue;
                    }
                    //check bounds
                    if (adjecentX >= CubicLayout.Width || adjecentY >= CubicLayout.Height || adjecentZ >= CubicLayout.Depth)
                    {
                        //adjecent x out-of-bounds, continue
                        continue;
                    }
                    //get adjecent resistance from resistance map
                    byte adjecentResistance = CubicLayout.inbuffer[adjecentX, adjecentY, adjecentZ];
                    //check traversability
                    if (adjecentResistance == 0)
                    {
                        //adjecent resistance non-traversable, continue
                        continue;
                    }
                    CubicNode adjecent;
                    //if adjecent x,y doesn't exist
                    if (!creationMap.ContainsKey(fxyzAdjecent))
                    {
                        //create node and set it as adjecent node
                        creationMap.Add(fxyzAdjecent, new CubicNode(adjecentX, adjecentY, adjecentZ));
                        adjecent = creationMap[fxyzAdjecent];
                    }
                    else
                    {
                        //or, if it exists, fetch it
                        adjecent = creationMap[fxyzAdjecent];
                    }
                    //calculate tentative path
                    uint tentativeGCost = current.gCost + adjecentResistance;
                    //if tentative path is ( longer then or same as ) current path
                    if (tentativeGCost >= adjecent.gCost)
                    {
                        //path is not better, continue
                        continue;
                    }
                    //calc heuristics if not calculated
                    if (adjecent.hCost == uint.MaxValue)
                    {
                        adjecent.hCost = adjecent.CalculateHeuristic(this);
                    }
                    //update this path lengt 
                    adjecent.gCost = tentativeGCost;
                    //update new path and cost
                    adjecent.parent = current;
                    adjecent.fCost = tentativeGCost + adjecent.hCost;
                    //open adjecent node
                    openQueue.Push(adjecent);
                }
            }
            //path could not be found
            memory.pathLength = -1;
            producingFrame = false;
            return;
        }
        #endregion

        #region Private: Produce Frame Helpers
        private void ReadyNextFrame()
        {
            if (memory.targetChanged)
            {
                creationMap.Clear();
                memory.targetChanged = false;
            }
            else
            {
                foreach (KeyValuePair<ulong, CubicNode> kvp in creationMap)
                {
                    kvp.Value.gCost = uint.MaxValue;
                    kvp.Value.fCost = uint.MaxValue;
                    kvp.Value.parent = null;
                }
            }
            closedSet.Clear();
            openQueue.Clear();
            //create target and retrieve pointer
            targetX = CubicMemory.targetX;
            targetY = CubicMemory.targetY;
            targetZ = CubicMemory.targetZ;
            fxyzTarget = Bytefuser.Fuse(targetX, targetY, targetZ, 0);
            if (creationMap.ContainsKey(fxyzTarget))
            {
                creationMap[fxyzTarget].hCost = 0;
            }
            else
            {
                creationMap.Add(fxyzTarget, new CubicNode(targetX, targetY, targetZ, 0));
            }
            //create start and retrieve pointer
            fxyzStart = Bytefuser.Fuse(CubicMemory.startX, CubicMemory.startY, CubicMemory.targetZ, 0);
            if (creationMap.ContainsKey(fxyzStart))
            {
                creationMap[fxyzStart] = new CubicNode(CubicMemory.startX, CubicMemory.startY, CubicMemory.targetZ, this);
            }
            else
            {
                creationMap.Add(fxyzStart, new CubicNode(CubicMemory.startX, CubicMemory.startY, CubicMemory.targetZ, this));
            }
            //insert start in open queue
            openQueue.Push(creationMap[fxyzStart]);
        }
        private void ConstructPath()
        {
            lock (outbufferLock)
            {
                ulong fxyzNext = fxyzTarget;
                int counter;
                for (counter = 0; counter < memory.OutBufferSize; counter++)
                {
                    //fill outbuffer
                    if (fxyzNext == fxyzStart)
                    {
                        break;
                    }
                    CubicMemory.outbuffer[counter] = fxyzNext;
                    CubicNode next = creationMap[fxyzNext].parent;
                    fxyzNext = Bytefuser.Fuse(next.xyz[0], next.xyz[1], next.xyz[2], 0);
                }
                memory.pathLength = counter;
            }
            return;
        }
        #endregion
    }
}

