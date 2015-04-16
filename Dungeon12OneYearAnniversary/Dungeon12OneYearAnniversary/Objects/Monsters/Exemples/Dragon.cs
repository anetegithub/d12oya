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
    internal sealed class Dragon : BMonster, IThing
    {
        public Dragon()
            : base(1.7, 0.5, 0.5, 2, 3, 75)
        { }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }

        public String Name { get { return "Dragon"; } }
        public String Info { get { return "Black. It's definitely a black dragon!"; } }
        public Boolean IsPassable { get { return false; } }
        public Char Icon { get { return 'D'; } }
        public ConsoleColor Color { get { return ConsoleColor.Black; } }
        public ConsoleColor Back { get { return ConsoleColor.Red; } }

        public void Action() { Activate(); }
    }
}