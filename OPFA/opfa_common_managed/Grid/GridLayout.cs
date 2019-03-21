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
        //public members
        public volatile byte[,] Inbuffer = null;

        #region Properties
        public ushort Width { get { return width; } }
        public ushort Height { get { return height; } }
        public uint InBufferSize { get { return (uint)(width * height); } }
        #endregion

        #region Constructor
        public GridLayout(ushort width, ushort height, byte baseCost = 127) : base(baseCost)
        {
            this.width = width;
            this.height = height;
        }
        #endregion

        #region Generate Layout
        public override void GenerateEmptyLayout()
        {
            Inbuffer = new byte[width, height];
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
                    Inbuffer[x, y] = baseCost;
                }
            });
#endif
        }
        public override void GenerateBlockRandomLayout(byte blockFrequency)
        {
            Inbuffer = new byte[width, height];
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
                        Inbuffer[x, y] = 0;
                    }
                    else
                    {
                        Inbuffer[x, y] = baseCost;
                    }
                }
            });
#endif
        }
        public override void GenerateRandomLayout(byte blockFrequency, byte resistanceCap)
        {
            Inbuffer = new byte[width, height];
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
                        Inbuffer[x, y] = 0;
                    }
                    else
                    {
                        Inbuffer[x, y] = (byte)StaticRandom.Rand(1, resistanceCap);
                    }
                }
            });
#endif
        }
        #endregion

        #region Get/Set Resistance
        public byte GetResistance(ushort x, ushort y)
        {
            return Inbuffer[x, y];
        }
        public void SetResistance(ushort x, ushort y, byte value)
        {
            Inbuffer[x, y] = value;
        }
        #endregion
    }
}
