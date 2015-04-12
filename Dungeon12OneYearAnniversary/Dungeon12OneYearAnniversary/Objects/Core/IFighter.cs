using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Objects
{
    internal interface IFighter
    {
        Field Ad { get; set; }
        Field MinDmg { get; set; }
        Field MaxDmg { get; set; }
        Int32 Attack(Int32 Armor);
    }
}
