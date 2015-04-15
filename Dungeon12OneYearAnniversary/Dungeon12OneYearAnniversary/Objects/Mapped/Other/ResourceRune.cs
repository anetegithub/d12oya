using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Map;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal sealed class ResourceRune : IThing
    {
        public ResourceRune()
        {
            _Sp = State.Current.Hero.Level;
            State.Current.Chat.Message(new IO.DrawerLine(IO.DCLine.New("There was a resource rune!", ConsoleColor.Red, ConsoleColor.White)));
        }

        private Int32 _Sp;
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Resource rune"; } }
        public String Info
        { get { return "Restore some resources!"; } }
        public Boolean IsPassable
        { get { return true; } }
        public Char Icon
        { get { return 'R'; } }
        public ConsoleColor Color
        { get { return (ConsoleColor)State.Current.Hero.SPColor.Enum(); } }
        public ConsoleColor Back
        { get { return ConsoleColor.White; } }
        public void Action()
        {
            IO.DrawerLine linew = new IO.DrawerLine();
            linew.DefaultForegroundColor = State.Current.Hero.Color;
            linew.DefaultBackgroundColor = ConsoleColor.White;
            linew += IO.DCLine.New("You", State.Current.Hero.Color, State.Current.Hero.Back);
            linew += "restore ~" + _Sp + " points!";

            State.Current.Chat.Message(linew);
            State.Current.GameField.Map[Position.X, Position.Y] = new Objects.Mapped.EThing();
            if (State.Current.Hero.Csp.Int() < State.Current.Hero.Msp.Int())
            {
                if (State.Current.Hero.Csp += _Sp > State.Current.Hero.Msp)
                    State.Current.Hero.Csp = State.Current.Hero.Msp;
                else
                    State.Current.Hero.Csp += _Sp;
            }
            State.Current.Info.Draw();
            State.Current.GameField.Draw();
        }
    }
}