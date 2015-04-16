using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Map;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal sealed class Trap : IThing
    {
        public Trap(Int32 Dmg)
        {
            _Dmg = Dmg;
            State.Current.Chat.Message(new IO.DrawerLine("Somebody set trap!", ConsoleColor.Yellow));
        }

        private Int32 _Dmg;
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Trap"; } }
        public String Info
        { get { return "It's green, you know..."; } }
        public Boolean IsPassable
        { get { return true; } }
        public Char Icon
        { get { return '¤'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.DarkYellow; } }
        public ConsoleColor Back
        { get { return ConsoleColor.Yellow; } }
        public void Action() { }
        public void Activate(IThing Target)
        {
            (Target as IAttackable).Chp -= this._Dmg;
            IO.DrawerLine line = new IO.DrawerLine();
            line += IO.DCLine.New(Target.Name, Target.Color, Target.Back);
            line += "get ";
            line += IO.DCLine.New(this._Dmg.ToString(), ConsoleColor.Red, ConsoleColor.White);
            line += " damage!";
            State.Current.Chat.Message(line);
            State.Current.GameField.Map[Position.X, Position.Y] = new Objects.Mapped.EThing();
            State.Current.GameField.Draw();
        }
    }
}