using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Map;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Objects.Mapped;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Skills;


namespace Dungeon12OneYearAnniversary.Objects.Monsters
{
    internal class BMonster : ITargetable, IFighter, IMagican, IMonster
    {
        /// <summary>
        /// Do not forget = Action(){ this.Activate; }
        /// </summary>
        /// <param name="HPRate">HeroMhp*this</param>
        /// <param name="ArmorRate">HeroLvl*this</param>
        /// <param name="BarrierRate">HeroLvl*this</param>
        /// <param name="MinDmgRate">HeroLvl*this</param>
        /// <param name="MaxDmgRate">HeroLvl*this + MinDmg</param>
        /// <param name="Exp">Exp</param>
        public BMonster(Double HPRate, Double ArmorRate, Double BarrierRate, Double MinDmgRate, Double MaxDmgRate, Int32 Exp)
        {
            Field Chp = 0;

            Chp = (Int32)(State.Current.Hero.Mhp.Int() * HPRate);
            Mhp = (Int32)(State.Current.Hero.Mhp.Int() * HPRate);
            Ap = 1;

            Loot = new Objects.Mapped.Gold();

            Chp.OnSet((Int32 Prev) =>
                {
                    if (this.Chp.Int() - Prev <= 0)
                    {
                        this.WhenDies();
                        return 0;
                    }
                    else
                        return Prev;
                });
            this.Chp = Chp; ;

            Armor = (Int32)(State.Current.Hero.Level.Int() * ArmorRate);
            Barrier = (Int32)(State.Current.Hero.Level.Int() * BarrierRate);

            MinDmg = (Int32)(State.Current.Hero.Level.Int() * MinDmgRate);
            MaxDmg = (Int32)((MinDmg.Int() * MaxDmgRate) + MinDmg.Int());

            this.Exp = Exp;
        }

        public Field Chp { get; set; }
        public Field Mhp { get; set; }

        public Field Ad { get; set; }
        public Field MinDmg { get; set; }
        public Field MaxDmg { get; set; }

        public Field Ap { get; set; }
        public Field MDmg { get; set; }

        public Field Armor { get; set; }
        public Field Barrier { get; set; }

        public Int32 Exp { get; set; }

        public IThing Loot { get; set; }

        public Int32 Attack(Int32 Armor)
        {
            Int32 Dmg = State.Random.Next(MinDmg, MaxDmg);
            Dmg -= (Int32)(Armor * 0.3);
            return Dmg < 0 ? 0 : Dmg;
        }
        private void Attacking()
        {
            Int32 Dmg = Attack(State.Current.Hero.Armor);
            State.Current.Hero.Chp -= Dmg;

            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = ConsoleColor.DarkGreen;
            Line.DefaultBackgroundColor = ConsoleColor.Black;

            if (this.GetType().GetInterface("IThing") != null)
                Line += DCLine.New((this as IThing).Name, (this as IThing).Color, (this as IThing).Back);
            else
                Line += "Monster";

            Line += " deals ";
            Line += DCLine.New(Dmg.ToString(), ConsoleColor.White, ConsoleColor.Red);
            Line += " damage!";

            State.Current.Chat.Message(Line);
        }

        public Int32 Cast(Int32 Barrier)
        {
            Int32 Dmg = MDmg.Int() * Ap.Int();
            Dmg -= (Int32)(Barrier * 0.2);
            return Dmg < 0 ? 0 : Dmg;
        }
        private void MagicAttacking()
        {
            Int32 Dmg = Cast(State.Current.Hero.Barrier);
            State.Current.Hero.Chp -= Dmg;

            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = ConsoleColor.DarkGreen;
            Line.DefaultBackgroundColor = ConsoleColor.Black;

            if (this.GetType().GetInterface("IThing") != null)
                Line += DCLine.New((this as IThing).Name, (this as IThing).Color, (this as IThing).Back);
            else
                Line += "Monster";

            Line += " deal ";
            Line += DCLine.New(Dmg.ToString(), ConsoleColor.White, ConsoleColor.Red);
            Line += DCLine.New(" magic", ConsoleColor.Magenta, ConsoleColor.White);
            Line += " damage!";

            State.Current.Chat.Message(Line);
        }
        private List<ISkill> Spells = new List<ISkill>();
        private void Casting()
        {
            if (Spells.Count == 0)
                MagicAttacking();
            else
                Spells[State.Random.Next(Spells.Count)].Use(State.Current.Hero);
        }

        public void WhenDies()
        {
            if (Loot != null && Loot.GetType() != typeof(EThing))
            {
                DrawerLine Line = new DrawerLine();
                Line.DefaultBackgroundColor = ConsoleColor.DarkGreen;
                Line.DefaultForegroundColor = ConsoleColor.White;
                Line += DCLine.New("You", State.Current.Hero.Color, State.Current.Hero.Back);
                Line += " get a ";
                Line += DCLine.New(Loot.Name, Loot.Color, Loot.Back);
                Line += " !";
                State.Current.Chat.Message(Line);
                Loot.Action();
            }

            State.Current.Hero.Cexp += Exp;

            if (this.GetType().GetInterface("IThing") != null)
            {
                DrawerLine Line = new DrawerLine();
                Line.DefaultBackgroundColor = ConsoleColor.DarkGreen;
                Line.DefaultForegroundColor = ConsoleColor.Black;
                Line += DCLine.New((this as IThing).Name, (this as IThing).Color, (this as IThing).Back);
                Line += " died! ";
                Line += DCLine.New("You", State.Current.Hero.Color, State.Current.Hero.Back);
                Line += " get ";
                Line += DCLine.New(Exp.ToString(), ConsoleColor.Blue, ConsoleColor.White);
                Line += " exp!";
                State.Current.Chat.Message(Line);
            }
            else
                State.Current.Chat.Message(new DrawerLine("Monster died! You get " + Exp.ToString() + " exp!", ConsoleColor.Magenta));

            if (this.GetType().GetInterface("IThing") != null)
                State.Current.GameField.Map[(this as IThing).Position.X, (this as IThing).Position.Y] = new Mapped.EThing();

            State.Current.GameField.Draw();
            State.Current.Info.Draw();
        }

        public void Activate()
        {
            if (State.Random.Next(2) == 0)
                Attacking();
            else if (MDmg.Int() != 0)
                Casting();
            else
                Attacking();
            State.Current.Info.Draw();
        }

        ~BMonster()
        {
            if (this.GetType().GetInterface("IThing") != null)
                State.Current.Chat.Message(new IO.DrawerLine((this as IThing).Name + " corpse disappeared", ConsoleColor.DarkGreen));
            else
                State.Current.Chat.Message(new IO.DrawerLine("Some corpse disappeared", ConsoleColor.DarkGreen));
        }
    }
}