using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Objects
{
    internal interface IMagican
    {
        Field Ap { get; set; }
        Field MDmg { get; set; }
        Int32 Cast(Int32 Barrier);
    }
}