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
    internal sealed class NewWeapon : IThing
    {
        public NewWeapon()
        {
            try
            {
                _Value = State.Random.Next((Int32)(State.Current.Hero.Chp.Int() * 0.018));
            }
            catch { }
            State.Current.Chat.Message(new IO.DrawerLine(IO.DCLine.New("Look there! This is a new weapon!", ConsoleColor.Cyan, ConsoleColor.Red)));
        }

        private Int32 _Value;
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "New weapon?"; } }
        public String Info
        { get { return "Nuff said"; } }
        public Boolean IsPassable
        { get { return true; } }
        public Char Icon
        { get { return '↑'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.Cyan; } }
        public ConsoleColor Back
        { get { return ConsoleColor.Red; } }
        public void Action()
        {
            Loudmouth.Yell(
                DCLine.New("attack power", ConsoleColor.Cyan, ConsoleColor.DarkMagenta),
                _Value,
                Position,
                () => { State.Current.Hero.Barrier += _Value; },
                new DrawerLine("The new weapon was old.", ConsoleColor.Cyan));
        }
    }
}