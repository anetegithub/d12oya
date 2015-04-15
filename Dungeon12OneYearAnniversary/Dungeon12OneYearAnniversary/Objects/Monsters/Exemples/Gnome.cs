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
    internal sealed class Gnome : BMonster, IThing
    {
        public Gnome()
            : base(0.7, 0, 0.4, 2, 3, 15)
        { }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }

        public String Name { get { return "Gnome"; } }
        public String Info { get { return "Little evil leprechaun with much gold."; } }
        public Boolean IsPassable { get { return false; } }
        public Char Icon { get { return 'g'; } }
        public ConsoleColor Color { get { return ConsoleColor.Blue; } }
        public ConsoleColor Back { get { return ConsoleColor.White; } }

        public void Action() { Activate(); }
    }
}