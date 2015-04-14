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
    internal sealed class BarrierVase : IThing
    {
        public BarrierVase()
        {
            try
            {
                _Value = State.Random.Next((Int32)(State.Current.Hero.Chp.Int() * 0.018));
            }
            catch { }
            State.Current.Msg.Message(new IO.DrawerLine(IO.DCLine.New("From the air drops bowl with chopsticks?", ConsoleColor.Magenta, ConsoleColor.DarkRed)));
        }

        private Int32 _Value;
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Vase wands"; } }
        public String Info
        { get { return "Vase with colorful magic wands. Smells good."; } }
        public Boolean IsPassable
        { get { return true; } }
        public Char Icon
        { get { return '‼'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.Magenta; } }
        public ConsoleColor Back
        { get { return ConsoleColor.DarkRed; } }
        public void Action()
        {
            Loudmouth.Yell(
                DCLine.New("barrier", ConsoleColor.DarkMagenta, ConsoleColor.Black),
                _Value,
                Position,
                () => { State.Current.Hero.Barrier += _Value; },
                new DrawerLine("Мase exploded. Again.", ConsoleColor.Magenta));
        }
    }
}