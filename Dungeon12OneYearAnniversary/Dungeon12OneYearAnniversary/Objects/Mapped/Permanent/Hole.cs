using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Map;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal sealed class Hole : IThing
    {
        public Hole()
            : base()
        {
            State.Current.Chat.Message(new IO.DrawerLine("Somewhere hit the floor...", ConsoleColor.DarkBlue));
        }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Hole"; } }
        public String Info
        { get { return "Big hole that can not be restored."; } }
        public Boolean IsPassable
        { get { return false; } }
        public Char Icon
        { get { return '█'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.DarkBlue; } }
        public ConsoleColor Back
        { get { return ConsoleColor.Black; } }
        public void Action()
        {
            State.Current.Chat.Message(new IO.DrawerLine("Be care!!!", ConsoleColor.DarkBlue));
        }
    }
}