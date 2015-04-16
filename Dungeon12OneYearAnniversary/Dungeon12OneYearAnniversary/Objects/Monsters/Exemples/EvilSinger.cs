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
    internal sealed class EvilSinger : BMonster, IThing
    {
        public EvilSinger()
            : base(0.9, 1.3, 0.1, 1, 3, 37)
        { }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }

        public String Name { get { return "Evil singer"; } }
        public String Info { get { return "Sings only evil music."; } }
        public Boolean IsPassable { get { return false; } }
        public Char Icon { get { return 'E'; } }
        public ConsoleColor Color { get { return ConsoleColor.DarkMagenta; } }
        public ConsoleColor Back { get { return ConsoleColor.Black; } }

        public void Action() { Activate(); }
    }
}