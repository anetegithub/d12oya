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
    internal sealed class Wolf : BMonster, IThing
    {
        public Wolf()
            : base(0.9, 1.3, 0.1, 2, 3, 37)
        { }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }

        public String Name { get { return "Wolf"; } }
        public String Info { get { return "In each 'rpg' game should be wolves."; } }
        public Boolean IsPassable { get { return false; } }
        public Char Icon { get { return 'W'; } }
        public ConsoleColor Color { get { return ConsoleColor.White; } }
        public ConsoleColor Back { get { return ConsoleColor.Blue; } }

        public void Action() { Activate(); }
    }
}