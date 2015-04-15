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
    internal sealed class MagicBook : IThing
    {
        public MagicBook()
        {
            try
            {
                _Value = State.Random.Next((Int32)(State.Current.Hero.Chp.Int() * 0.018));
            }
            catch { }
            State.Current.Chat.Message(new IO.DrawerLine(IO.DCLine.New("Magic brings a whirlwind book!", ConsoleColor.Magenta, ConsoleColor.DarkMagenta)));
        }

        private Int32 _Value;
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Magic book"; } }
        public String Info
        { get { return "It seems that in this book there are spells."; } }
        public Boolean IsPassable
        { get { return true; } }
        public Char Icon
        { get { return '≡'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.Magenta; } }
        public ConsoleColor Back
        { get { return ConsoleColor.DarkMagenta; } }
        public void Action()
        {
            Loudmouth.Yell(
                DCLine.New("ability power", ConsoleColor.Magenta, ConsoleColor.DarkMagenta),
                _Value,
                Position,
                () => { State.Current.Hero.Barrier += _Value; },
                new DrawerLine("The book was burned in the magical flames.", ConsoleColor.Magenta));
        }
    }
}