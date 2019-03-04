using System.Collections.Generic;

namespace opfa_common_managed
{
    internal class GridPathfinder : Pathfinder<GridNode, uint>
    {
        //static private members
        private static short[,] offsets = new short[8, 2] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 }, { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
        //private members
        internal ushort targetX;
        internal ushort targetY;
        private uint fxyTarget;
        private uint fxyStart;
        private byte offsetCount;
        //properties
        public GridMemory GridMemory { get { return (memory as GridMemory); } }
        public GridLayout GridLayout { get { return (memory.Layout as GridLayout); } }

        #region Constructor
        internal GridPathfinder(GridMemory gridMemory) : base(gridMemory)
        {
            creationMap = new Dictionary<uint, GridNode>();
            #if v35
            openQueue = new PriorityQueue<GridNode>((int)memory.OutBufferSize, new GridOpenComparer());
            #else
            openQueue = new PriorityQueue<GridNode>((int)memory.OutBufferSize, new OpenComparer<GridNode, uint>());
            #endif
            closedSet = new HashSet<uint>();
            //set which adjecent offsets to include in path
            if (GridLayout.IncludeDiagonals)
            {
                //diagonals included
                offsetCount = 8;
            }
            else
            {
                //diagonals excluded
                offsetCount = 4;
            }
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
                GridNode current = openQueue.Top;
                //if current is target
                if (current == creationMap[fxyTarget])
                {
                    //frame done, construct path
                    producingFrame = false;
                    ConnstructPath();
                    return;
                }
                #region TEST
                /*if (openQueue.Count > 40)
                {
                    int sta = openQueue.Count;
                    uint lastfcost = 0;
                    for (int q = 0; q < sta; q++)
                    {
                        uint _fcost = openQueue.Top.fCost;
                        ushort[] pos = openQueue.Top.xy;
                        if (lastfcost > _fcost)
                        {
                            throw new System.Exception();
                        }
                        lastfcost = _fcost;
                        openQueue.Pop();
                    }
                    int yuo = 0;
                    yuo++;
                }*/
                #endregion
                //pop current from queue
                openQueue.Pop();
                //close the node
                closedSet.Add(Bytefuser.Fuse(current.xy[0], current.xy[1]));
                //foreach adjecent count
                for (int i = 0; i < offsetCount; i++)
                {
                    //calculate adjecent x,y
                    ushort adjecentX = (ushort)(current.xy[0] + offsets[i, 0]);
                    ushort adjecentY = (ushort)(current.xy[1] + offsets[i, 1]);
                    //fuse adjecent x,y
                    uint fxyAdjecent = Bytefuser.Fuse(adjecentX, adjecentY);
                    //if adjecent fxy is closed
                    if (closedSet.Contains(fxyAdjecent))
                    {
                        //node closed, continue
                        continue;
                    }
                    //check bounds
                    if (adjecentX >= GridLayout.Width || adjecentY >= GridLayout.Height)
                    {
                        //adjecent x out-of-bounds, continue
                        continue;
                    }
                    //get adjecent resistance from resistance map
                    byte adjecentResistance = GridLayout.inbuffer[adjecentX, adjecentY];
                    //check if layout uses a diagonal modifier and if the adjecent node is diagonal
                    if(GridLayout.UseDiagonalModifier && i > 3)
                    {
                        //add diagonal modifier for path smoothing
                        adjecentResistance = (byte)(adjecentResistance * GridLayout.DiagonalModifier);
                    }
                    //check traversability
                    if (adjecentResistance == 0)
                    {
                        //adjecent resistance non-traversable, continue
                        continue;
                    }
                    GridNode adjecent;
                    //if adjecent x,y doesn't exist
                    if (!creationMap.ContainsKey(fxyAdjecent))
                    {
                        //create node and set it as adjecent node
                        creationMap.Add(fxyAdjecent, new GridNode(adjecentX, adjecentY));
                        adjecent = creationMap[fxyAdjecent];
                    }
                    else
                    {
                        //or, if it exists, fetch it
                        adjecent = creationMap[fxyAdjecent];
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
                    adjecent.fxyParent = Bytefuser.Fuse(current.xy[0], current.xy[1]);
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
                foreach (KeyValuePair<uint, GridNode> kvp in creationMap)
                {
                    kvp.Value.gCost = uint.MaxValue;
                    kvp.Value.fCost = uint.MaxValue;
                    kvp.Value.fxyParent = 0;
                }
            }
            closedSet.Clear();
            openQueue.Clear();
            //create and init target
            targetX = GridMemory.targetX;
            targetY = GridMemory.targetY;
            fxyTarget = Bytefuser.Fuse(targetX, targetY);
            if (creationMap.ContainsKey(fxyTarget))
            {
                creationMap[fxyTarget].hCost = 0;
            }
            else
            {
                creationMap.Add(fxyTarget, new GridNode(targetX, targetY, 0));
            }
            //create and init start
            fxyStart = Bytefuser.Fuse(GridMemory.startX, GridMemory.startY);
            if (creationMap.ContainsKey(fxyStart))
            {
                creationMap[fxyStart] = new GridNode(GridMemory.startX, GridMemory.startY, this);
            }
            else
            {
                creationMap.Add(fxyStart, new GridNode(GridMemory.startX, GridMemory.startY, this));
            }
            //insert start in open queue
            openQueue.Push(creationMap[fxyStart]);
        }
        private void ConnstructPath()
        {
            lock (outbufferLock)
            {
                uint fxyNext = fxyTarget;
                int counter;
                for (counter = 0; counter < memory.OutBufferSize; counter++)
                {
                    //fill outbuffer
                    if (fxyNext == fxyStart)
                    {
                        break;
                    }
                    GridMemory.outbuffer[counter] = fxyNext;
                    fxyNext = creationMap[fxyNext].fxyParent;
                }
                memory.pathLength = counter;
            }
            return;
        }
        #endregion
    }
}

