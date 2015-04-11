using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Objects.Monsters.Exemples
{
    internal sealed class Rat : BMonster, IMonster
    {
        public Rat()
            : base()
        {
            Chp = (Int32)(State.Current.Hero.Mhp / 10);
            Mhp = (Int32)(State.Current.Hero.Mhp / 10);

            Chp.SetInt((Int32 Prev) =>
                {
                    if (Chp.ToInt() - Prev <= 0)
                    {
                        if (this.__Loot != null)
                        {
                            State.Current.Hero.Inventory.Add(__Loot);

                            DrawerLine Line = new DrawerLine();
                            Line += DCLine.New("You get a ", ConsoleColor.Blue, ConsoleColor.Black);
                            Line += DCLine.New(__Loot.Name, __Loot.Color, __Loot.Back);
                            Line += DCLine.New(" !", ConsoleColor.Blue, ConsoleColor.Black);

                            State.Current.Msg.Message(Line);
                        }
                        State.Current.Msg.Message(new DrawerLine("Rat died! You get " + Exp.ToInt().ToString() + " exp!", ConsoleColor.Magenta));
                        State.Current.GameField.Map[Position.X, Position.Y] = new Mapped.EThing();
                        State.Current.Hero.Cexp += Exp.ToInt();
                        return 0;
                    }
                    else
                        return Prev;
                });

            Mdf = (Int32)(State.Current.Hero.Level / 2);
            Pdf = (Int32)(State.Current.Hero.Level);

            MinDmg = (Int32)(State.Current.Hero.Level);
            MaxDmg = (Int32)((MinDmg.ToInt() * 1.5) + MinDmg.ToInt());

            Exp = 1;
        }

        protected override string _Name
        {
            get
            {
                return "Rat";
            }
            set { }
        }

        protected override ConsoleColor _Color
        {
            get { return ConsoleColor.Yellow; }
            set { }
        }

        protected override ConsoleColor _Back
        {
            get
            {
                return ConsoleColor.Black;
            }
            set
            {

            }
        }

        protected override char _Icon
        {
            get
            {
                return 'R';
            }
            set
            {

            }
        }

        protected override string _Info
        {
            get
            {
                return "One of dirty rats!";
            }
            set
            {

            }
        }

        private IThing __Loot;
        protected override IThing Loot
        {
            get
            {
                if (__Loot == null)
                    __Loot = new Objects.Mapped.EThing(); //random
                return __Loot;
            }
            set
            {
                __Loot = value;
            }
        }

        private void Attack()
        {
            Int32 Dmg = State.Random.Next(MinDmg, MaxDmg);
            State.Current.Hero.Chp -= Dmg;
            State.Current.Msg.Message(new IO.DrawerLine("Rat deals " + Dmg + " damage", ConsoleColor.Yellow));
        }

        private void Bite()
        {
            Int32 Dmg = State.Random.Next(MinDmg, MaxDmg) * 2;
            State.Current.Hero.Chp -= Dmg;
            State.Current.Msg.Message(new IO.DrawerLine("Rat bites on " + Dmg + " damage", ConsoleColor.Yellow));
        }

        protected override void Activate()
        {
            if (State.Random.Next(2) == 0)
                Attack();
            else
                Bite();
        }

        public Field Chp { get; set; }
        public Field Mhp { get; set; }

        public Field Mdf { get; set; }
        public Field Pdf { get; set; }

        public Field MinDmg { get; set; }
        public Field MaxDmg { get; set; }

        public Field Exp { get; set; }

        ~Rat()
        {
            State.Current.Msg.Message(new DrawerLine("Rat corpse disappeared", ConsoleColor.DarkGreen));
        }
    }
}