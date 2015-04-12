using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Objects.Monsters.Exemples
{
    internal sealed class Zombie : BMonster, IThing
    {
        public Zombie()
            : base(0.2, 0, 0.5, 1, 2, 5)
        { }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }

        public String Name { get { return "Zombie"; } }
        public String Info { get { return "Live rotting corpse"; } }
        public Boolean IsPassable { get { return false; } }
        public Char Icon { get { return 'Z'; } }
        public ConsoleColor Color { get { return ConsoleColor.Green; } }
        public ConsoleColor Back { get { return ConsoleColor.DarkGreen; } }

        public void Action() { Activate(); }
    }
}