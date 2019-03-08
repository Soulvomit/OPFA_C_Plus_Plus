#if v35
using System;
#else
using System.Threading.Tasks;
#endif

namespace opfa_common_managed
{
    public sealed class CubicLayout : Layout
    {
        //private members
        private ushort width;
        private ushort height;
        private ushort depth;
        private ulong inbufferSize;
        //public members
        public volatile byte[,,] inbuffer;

        #region Properties
        public ushort Width { get { return width; } }
        public ushort Height { get { return height; } }
        public ushort Depth { get { return depth; } }
        public ulong InBufferSize { get { return inbufferSize; } }
        #endregion

        #region Constructor
        public CubicLayout(ushort width, ushort height, ushort depth, byte baseCost = 127) : base(baseCost)
        {
            inbufferSize = (ulong)(width * height * depth);
            inbuffer = new byte[width, height, depth];
            this.width = width;
            this.height = height;
            this.depth = depth;
        }
        #endregion

        #region Generate Layout
        public override void GenerateEmptyLayout()
        {
            #if v35
            //.NET 3.5
            for (int z = 0; z < depth; z++)
            {
                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; x++)
                    {

                        inbuffer[x, y, z] = baseCost;
                    }
                }
            }
            #else
            //above .NET 3.5
            Parallel.For(0, depth, z =>
            {
                Parallel.For(0, height, y =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        inbuffer[x, y, z] = 0; 
                    }
                });
            });
            #endif
        }
        public override void GenerateBlockRandomLayout(byte blockFrequency)
        {
            #if v35
            //.NET 3.5
            //initialize random seed
            Random rand = new Random();
            for (int z = 0; z < depth; z++)
            {
                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (rand.Next(0, blockFrequency) == 0)
                        {
                            inbuffer[x, y, z] = 0;
                        }
                        else
                        {
                            inbuffer[x, y, z] = baseCost;
                        }
                    }
                }
            }
            #else
            //above .NET 3.5
            Parallel.For(0, depth, (z, loopState) =>
            {
                //Parallel.For(0, height, y =>
                //{
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (StaticRandom.Rand(0, blockFrequency) == 0)
                        {
                            inbuffer[x, y, z] = 0;
                        }
                        else
                        {
                            inbuffer[x, y, z] = baseCost;
                        }
                    }
                }
                //});
            });
            #endif
        }
        public override void GenerateRandomLayout(byte blockFrequency, byte resistanceCap)
        {
            #if v35
            //.NET 3.5
            //initialize random seed
            Random rand = new Random();
            for (int z = 0; z < depth; z++)
            {
                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (rand.Next(0, blockFrequency) == 0)
                        {
                            inbuffer[x, y, z] = 0;
                        }
                        else
                        {
                            inbuffer[x, y, z] = (byte)rand.Next(1, resistanceCap);
                        }
                    }
                }
            }
            #else
            //above .NET 3.5
            Parallel.For(0, depth, (z, loopState ) =>
            {
                //Parallel.For(0, height, y =>
                //{
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (StaticRandom.Rand(0, blockFrequency) == 0)
                        {
                            inbuffer[x, y, z] = 0;
                        }
                        else
                        {
                            inbuffer[x, y, z] = (byte)StaticRandom.Rand(1, resistanceCap);
                        }
                    }
                }
                //});
            });
            #endif
        }
        #endregion

        #region Get/Set Resistances
        public byte GetResistance(ushort x, ushort y, ushort z)
        {
            return inbuffer[x, y, z];
        }
        public void SetResistance(ushort x, ushort y, ushort z, byte value)
        {
            inbuffer[x, y, z] = value;
        }
        #endregion
    }
}
