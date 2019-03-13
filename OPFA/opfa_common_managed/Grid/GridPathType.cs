using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opfa_common_managed
{
    public enum GridPathType: byte
    {
        Normal = 0,
        NoDiagonals = 1,
        WeightedDiagonals = 2
    }
}
