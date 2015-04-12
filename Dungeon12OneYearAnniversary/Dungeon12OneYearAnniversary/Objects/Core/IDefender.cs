using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Objects
{
    internal interface IDefender
    {
        Field Armor { get; set; }
        Field Barrier { get; set; }
    }
}
