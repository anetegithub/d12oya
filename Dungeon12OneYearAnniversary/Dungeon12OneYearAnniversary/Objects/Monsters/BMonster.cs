using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Map;

namespace Dungeon12OneYearAnniversary.Objects.Monsters
{
    internal class BMonster : IThing
    {
        protected virtual IThing Loot { get; set; }
        protected virtual String _Name { get; set; }
        protected virtual String _Info { get; set; }
        protected virtual Char _Icon { get; set; }
        protected virtual ConsoleColor _Color { get; set; }
        protected virtual ConsoleColor _Back { get; set; }
        protected virtual void Activate() { Console.WriteLine("Not emplement!"); }

        public Coord Position { get; set; }
        public IThing Bag
        {
            get { return Loot; }
            set { Loot = value; }
        }
        public String Name { get { return _Name; } }
        public String Info { get { return _Info; } }
        public Boolean IsPassable { get { return false; } }
        public Char Icon { get { return _Icon; } }
        public ConsoleColor Color { get { return _Color; } }
        public ConsoleColor Back { get { return _Back; } }
        public void Action() { Activate(); }
    }
}