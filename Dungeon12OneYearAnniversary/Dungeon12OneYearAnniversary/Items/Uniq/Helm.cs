using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Items.Uniq
{
    internal sealed class Helm : BItem, IThing
    {
        public Helm()
            : base(
            () =>
            {
                State.Current.Hero.Chp.SetInt(UniqHealingEffect);
            },
            () =>
            {
                State.Current.Hero.Chp.DelInt(UniqHealingEffect);
            })
        { }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Healing Helm"; } }
        public String Info
        { get { return "Uniq healing helm. Heal 1 hp each step."; } }
        public Boolean IsPassable
        { get { return false; } }
        public Char Icon
        { get { return '+'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.Red; } }
        public ConsoleColor Back
        { get { return ConsoleColor.White; } }
        public void Action()
        { Activate(); }

        public static Int32 UniqHealingEffect(Int32 Prev)
        {
            if (State.Current.Hero.Chp.ToInt() < State.Current.Hero.Mhp.ToInt())
            {
                State.Current.Hero.Chp += 1;

                DrawerLine Line = new DrawerLine();
                Line.DefaultBackgroundColor = ConsoleColor.DarkGreen;
                Line.DefaultForegroundColor = ConsoleColor.Black;
                Line += DCLine.New("Healing Helm", ConsoleColor.Red, ConsoleColor.White);
                Line += DCLine.New(" speciall effect ", ConsoleColor.Magenta, ConsoleColor.Black);
                Line += DCLine.New("'Healing touch'", ConsoleColor.Red, ConsoleColor.White);
                Line += DCLine.New(" heal ", State.Current.Hero.Color, State.Current.Hero.Back);
                Line += DCLine.New("1", ConsoleColor.Red, ConsoleColor.White);
                Line += " hp!";
                State.Current.Msg.Message(Line);

                State.Current.Info.Draw();
            }

            return Prev;
        }
    }
}