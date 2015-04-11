using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Map;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal sealed class EThing : IThing
    {
        public Coord Position { get; set; }

        private IThing _Bag;
        public IThing Bag
        { get { return _Bag; } set { _Bag = value; } }

        public String Name
        { get { return "Nothing"; } }
        public String Info
        { get { return "Just nothing"; } }
        public Boolean IsPassable
        { get { return true; } }
        public Char Icon
        { get { return ' '; } }
        public ConsoleColor Color
        { get { return ConsoleColor.Black; } }
        public ConsoleColor Back
        { get { return ConsoleColor.Black; } }
        public void Action()
        { }
    }
}