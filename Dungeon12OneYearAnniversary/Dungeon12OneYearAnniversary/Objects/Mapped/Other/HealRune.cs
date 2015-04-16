using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Map;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal sealed class HealRune : IThing
    {
        public HealRune()
        {
            _Hp = State.Current.Hero.Level*7;
            State.Current.Chat.Message(new IO.DrawerLine(IO.DCLine.New("There was a red rune!", ConsoleColor.Red, ConsoleColor.White)));
        }

        private Int32 _Hp;
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Red rune"; } }
        public String Info
        { get { return "Heal some hit points!"; } }
        public Boolean IsPassable
        { get { return true; } }
        public Char Icon
        { get { return 'R'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.Red; } }
        public ConsoleColor Back
        { get { return ConsoleColor.White; } }
        public void Action()
        {
            IO.DrawerLine linew = new IO.DrawerLine();
            linew.DefaultForegroundColor = ConsoleColor.Red;
            linew.DefaultBackgroundColor = ConsoleColor.White;
            linew += IO.DCLine.New("You", State.Current.Hero.Color, State.Current.Hero.Back);
            linew += "heal ~" + _Hp + " points!";

            State.Current.Chat.Message(linew);
            State.Current.GameField.Map[Position.X, Position.Y] = new Objects.Mapped.EThing();
            if (State.Current.Hero.Chp.Int() < State.Current.Hero.Mhp.Int())
            {
                if (State.Current.Hero.Chp += _Hp > State.Current.Hero.Mhp)
                    State.Current.Hero.Chp = State.Current.Hero.Mhp;
                else
                    State.Current.Hero.Chp += _Hp;
            }
            State.Current.Info.Draw();
            State.Current.GameField.Draw();
        }
    }
}