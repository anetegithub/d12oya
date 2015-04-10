using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Game;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal sealed class EThing : IThing
    {
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