using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Map;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal sealed class Gold : IThing
    {
        public Gold()
        {
            _Gold = State.Random.Next(1, (Int32)(State.Current.Hero.Level.Int() * 1.56463));
            State.Current.Msg.Message(new IO.DrawerLine("Somebody dropped some coins!", ConsoleColor.Yellow));
        }

        private Int32 _Gold;
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Gold"; } }
        public String Info
        { get { return "Some gold coins!"; } }
        public Boolean IsPassable
        { get { return true; } }
        public Char Icon
        { get { return '∙'; } }//'▲'
        public ConsoleColor Color
        { get { return ConsoleColor.DarkYellow; } }
        public ConsoleColor Back
        { get { return ConsoleColor.Yellow; } }
        public void Action()
        {
            State.Current.Msg.Message(new IO.DrawerLine(IO.DCLine.New("You get " + _Gold.ToString() + " gold coins!", ConsoleColor.DarkYellow, ConsoleColor.Yellow)));
            State.Current.GameField.Map[Position.X, Position.Y] = new Objects.Mapped.EThing();
            State.Current.Hero.Gold += _Gold;
            State.Current.Info.Draw();
            State.Current.GameField.Draw();
        }
    }
}