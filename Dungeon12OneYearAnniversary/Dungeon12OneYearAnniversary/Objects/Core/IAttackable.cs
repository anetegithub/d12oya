using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Objects
{
    internal interface IAttackable
    {
        Field Chp { get; set; }
        Field Mhp { get; set; }
        Int32 Exp { get; set; }
        void WhenDies();
    }
}