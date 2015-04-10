using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Heroes
{
    internal sealed class Person
    {
        public Field Name { get; set; }
        public Field Class { get; set; }
        public Field Race { get; set; }

        public Field Level { get; set; }
    }
}