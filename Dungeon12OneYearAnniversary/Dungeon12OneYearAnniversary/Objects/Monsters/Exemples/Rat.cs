using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Objects.Mapped;

namespace Dungeon12OneYearAnniversary.Objects.Monsters.Exemples
{
    internal sealed class Rat : BMonster, IThing
    {
        public Rat()
            : base(0.1, 1, 0.2, 1, 1.5, 1)
        { }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }

        public String Name { get { return "Rat"; } }
        public String Info { get { return "Just one(?) little dirty rat!"; } }
        public Boolean IsPassable { get { return false; } }
        public Char Icon { get { return 'r'; } }
        public ConsoleColor Color { get { return ConsoleColor.Gray; } }
        public ConsoleColor Back { get { return ConsoleColor.DarkGray; } }

        public void Action() { Activate(); }
    }
}