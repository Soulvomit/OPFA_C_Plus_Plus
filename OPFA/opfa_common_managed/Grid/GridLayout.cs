#if v35
using System;
#else
using System.Threading.Tasks;
#endif

namespace opfa_common_managed
{
    public sealed class GridLayout : Layout
    {
        //private members
        private ushort width;
        private ushort height;
        private bool includeDiagonals;
        private bool useDiagonalModifier;
        private float diagonalModifier;
        private uint inbufferSize;
        //public members
        public volatile byte[,] inbuffer;

        #region Properties
        public ushort Width { get { return width; } }
        public ushort Height { get { return height; } }
        public bool IncludeDiagonals { get { return includeDiagonals; } }
        public bool UseDiagonalModifier { get { return useDiagonalModifier; } }
        public float DiagonalModifier { get { return diagonalModifier; } }
        public uint InBufferSize { get { return inbufferSize; } }
        #endregion

        #region Constructor
        public GridLayout(ushort width, ushort height, bool includeDiagonals = true, bool useDiagonalModifier = true, float diagonalModifier = 1.4f, byte baseCost = 10) : base(baseCost)
        {
            inbufferSize = (uint)(width * height);
            inbuffer = new byte[width, height];
            this.width = width;
            this.height = height;
            this.includeDiagonals = includeDiagonals;
            this.useDiagonalModifier = useDiagonalModifier;
            this.diagonalModifier = diagonalModifier;
        }
        #endregion

        #region Generate Layout
        public override void GenerateEmptyLayout()
        {
            #if v35
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; x++)
                {
                    inbuffer[x, y] = baseCost;
                }
            }
            #else
            //above .NET 3.5
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    inbuffer[x, y] = baseCost;
                }
            });
            #endif
        }
        public override void GenerateBlockRandomLayout(byte blockFrequency)
        {
            //initialize random seed
            #if v35
            Random rand = new Random();
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; x++)
                {
                    if (rand.Next(0, blockFrequency) == 0)
                    {
                        inbuffer[x, y] = 0;
                    }
                    else
                    {
                        inbuffer[x, y] = baseCost;
                    }
                }
            }
            #else
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    if (StaticRandom.Rand(0, blockFrequency) == 0)
                    {
                        inbuffer[x, y] = 0;
                    }
                    else
                    {
                        inbuffer[x, y] = baseCost;
                    }
                }
            });
            #endif
        }
        public override void GenerateRandomLayout(byte blockFrequency, byte resistanceCap)
        {
            //initialize random seed
            #if v35
            Random rand = new Random();
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; x++)
                {
                    if (rand.Next(0, blockFrequency) == 0)
                    {
                        inbuffer[x, y] = 0;
                    }
                    else
                    {
                        inbuffer[x, y] = (byte)rand.Next(1, resistanceCap);
                    }
                }
            }
            #else
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    if (StaticRandom.Rand(0, blockFrequency) == 0)
                    {
                        inbuffer[x, y] = 0;
                    }
                    else
                    {
                        inbuffer[x, y] = (byte)StaticRandom.Rand(1, resistanceCap);
                    }
                }
            });
            #endif
        }
        #endregion

        #region Get/Set Resistance
        public byte GetResistance(ushort x, ushort y)
        {
            return inbuffer[x, y];
        }
        public void SetResistance(ushort x, ushort y, byte value)
        {
            inbuffer[x, y] = value;
        }
        #endregion
    }
}
