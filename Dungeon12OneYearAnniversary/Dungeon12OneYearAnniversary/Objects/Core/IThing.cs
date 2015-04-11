using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Map;

namespace Dungeon12OneYearAnniversary.Objects
{
    interface IThing
    {
        Coord Position { get; set; }
        IThing Bag { get; set; }
        String Name { get; }
        String Info { get; }
        Boolean IsPassable { get; }
        Char Icon { get; }
        ConsoleColor Color { get; }
        ConsoleColor Back { get; }
        void Action();
    }
}