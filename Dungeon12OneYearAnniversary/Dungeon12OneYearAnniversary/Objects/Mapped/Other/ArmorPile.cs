using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Map;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal sealed class ArmorPile : IThing
    {
        public ArmorPile()
        {
            _Value = State.Random.Next((Int32)(State.Current.Hero.Chp.Int() * 0.018));
            State.Current.Chat.Message(new IO.DrawerLine(IO.DCLine.New("From under a pile of mud peeps metal!!", ConsoleColor.Gray, ConsoleColor.DarkGray)));
        }

        private Int32 _Value;
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Pile of old ammunition"; } }
        public String Info
        { get { return "Inside you can find a variety of armor and other protective equipment..."; } }
        public Boolean IsPassable
        { get { return true; } }
        public Char Icon
        { get { return '▲'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.Gray; } }
        public ConsoleColor Back
        { get { return ConsoleColor.DarkGray; } }
        public void Action()
        {
            Loudmouth.Yell(
                DCLine.New("armor", ConsoleColor.DarkCyan, ConsoleColor.Black),
                _Value,
                Position,
                () => { State.Current.Hero.Armor += _Value; },
                new DrawerLine("A pile of garbage disappears...", ConsoleColor.DarkGreen));
        }
    }
}