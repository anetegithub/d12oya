using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Map;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal sealed class Rock : IThing
    {
        public Rock()
            : base()
        {
            State.Current.Chat.Message(new IO.DrawerLine("From the ceiling fell stone!", ConsoleColor.DarkCyan));
        }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Rock"; } }
        public String Info
        { get { return "Just rock"; } }
        public Boolean IsPassable
        { get { return false; } }
        public Char Icon
        { get { return '#'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.DarkCyan; } }
        public ConsoleColor Back
        { get { return ConsoleColor.Black; } }
        public void Action()
        {
            State.Current.Chat.Message(new IO.DrawerLine("It's ROCK!", ConsoleColor.DarkCyan));
        }
    }
}
