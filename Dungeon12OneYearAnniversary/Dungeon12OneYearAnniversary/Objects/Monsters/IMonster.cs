using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Objects.Monsters
{
    internal interface IMonster
    {
        Field Chp { get; set; }
        Field Mhp { get; set; }

        Field Mdf { get; set; }
        Field Pdf { get; set; }

        Field MinDmg { get; set; }
        Field MaxDmg { get; set; }

        Field Exp { get; set; }
    }
}