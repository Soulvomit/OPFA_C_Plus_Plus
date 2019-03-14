using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opfa_common_managed
{
    public struct Profile
    {
        public long MapCreationTime;
        public long PathRunTime;
        public long PathRunTimeTicks;
        public int PathLength;
        public uint[,] Path;
    }
}
