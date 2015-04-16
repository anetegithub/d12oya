using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Skills
{
    internal class BSkill
    {
        public BSkill(Int32 Cost, Int32 CostScale, Scale FromScale, Int32 Power, Double PowerScale, Double LevelScale)
        {
            this.Cost = Cost;
            this.CostScale = CostScale;
            this.Scale = FromScale;
            this.Power = Power;
            this.PowerScale = PowerScale;
            this.LevelScale = LevelScale;
            HeroRef = State.Current.Hero;
        }
        protected Heroes.Person HeroRef;

        protected Int32 _Level = 0;
        public void IncrementLevel() { _Level++; }

        protected Int32 Cost = 0;
        protected Int32 CostScale = 0;
        
        protected Int32 Power = 0;
        protected Double PowerScale = 0;

        protected Scale Scale;
        protected Double LevelScale = 0;
        private Double CurrentLevelScaled = 0;

        protected Boolean CanCast()
        {
            if (HeroRef.Csp.Int() - Cost <= 0)
            {
                DrawerLine Line = new DrawerLine();
                Line.DefaultForegroundColor = HeroRef.Color;
                Line.DefaultBackgroundColor = HeroRef.Back;
                Line += "Not enough ";
                Line += DCLine.New(HeroRef.SPName, (ConsoleColor)HeroRef.SPColor.Enum(), ConsoleColor.White);
                Line += " !";
                Temp.State.Current.Chat.Message(Line);

                return false;
            }
            return true;
        }

        protected Int32 Dmg()
        {
            if (Scale == Skills.Scale.Ap)
                return Power + (Int32)(PowerScale * HeroRef.Ap.Int());
            else
                return Power + (Int32)(PowerScale * HeroRef.Ad.Int());
        }
        protected Int32 Dmg(Scale Scale)
        {
            if (Scale == Skills.Scale.Ap)
                return Power + (Int32)(PowerScale * HeroRef.Ap.Int());
            else
                return Power + (Int32)(PowerScale * HeroRef.Ad.Int());
        }
        protected Int32 Dmg(IDefender Target)
        {
            Int32 TrueDmg = Dmg();

            if (Scale == Skills.Scale.Ap)
                TrueDmg -= Target.Armor.Int();
            else
                TrueDmg -= Target.Barrier.Int();

            if (TrueDmg < 0) TrueDmg = 0;

            return TrueDmg;
        }

        protected Action LevelUpAddition = null;
        protected void RunLevelUp()
        {
            this._Level++;

            this.Cost += CostScale;

            if (CurrentLevelScaled + LevelScale > 1)
            {
                this.Power++;
                CurrentLevelScaled = 0;
            }
            else
                CurrentLevelScaled += LevelScale;

            if (Scale == Skills.Scale.Ap)
                this.Power += (Int32)(HeroRef.Ap * PowerScale);
            else
                this.Power += (Int32)(HeroRef.Ad * PowerScale);

            if (LevelUpAddition != null)
                LevelUpAddition();
        }
    }

    internal enum Scale { Ap = 0, Ad = 1 }
}