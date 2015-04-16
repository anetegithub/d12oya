using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Activity
{
    internal static class SkillMngr
    {
        public static void SetSkills()
        {
            switch ((Heroes.Class)State.Current.Hero.Class.Enum())
            {
                case Heroes.Class.BloodMage: BloodMage(); return;
                case Heroes.Class.Paladin: Paladin(); return;
                case Heroes.Class.Alchemist: Alchemist(); return;
                case Heroes.Class.Rogue: Rogue(); return;
                case Heroes.Class.FireMage: FireMage(); return;
                default: return;
            }
        }

        private static void FireMage()
        {
            State.Current.Hero.Q = new Skills.ClassSkills.FireArrow();
            State.Current.Hero.W = new Skills.ClassSkills.FireNova();
            State.Current.Hero.E = new Skills.ClassSkills.FireWeapon();
            State.Current.Hero.R = new Skills.ClassSkills.Explosion();
        }

        private static void Rogue()
        {
            State.Current.Hero.Q = new Skills.ClassSkills.SimplePoison();
            State.Current.Hero.W = new Skills.ClassSkills.DeadlyPoison();
            State.Current.Hero.E = new Skills.ClassSkills.WeakeningPoison();
            State.Current.Hero.R = new Skills.ClassSkills.Trap();
        }

        private static void Alchemist()
        {
            State.Current.Hero.Q = new Skills.ClassSkills.RainbowSpray();
            State.Current.Hero.W = new Skills.ClassSkills.BottleOfElements();
            State.Current.Hero.E = new Skills.ClassSkills.BrewPotion();
            State.Current.Hero.R = new Skills.ClassSkills.Alchemy();
            State.Current.Hero.R.LevelUp();
        }

        private static void Paladin()
        {
            State.Current.Hero.Q = new Skills.ClassSkills.HolyLight();
            State.Current.Hero.W = new Skills.ClassSkills.PillarOfLight();
            State.Current.Hero.E = new Skills.ClassSkills.BanishEvil();
            State.Current.Hero.R = new Skills.ClassSkills.HolyStrike();
        }

        private static void BloodMage()
        {
            State.Current.Hero.Q = new Skills.ClassSkills.Vampirism();
            State.Current.Hero.W = new Skills.ClassSkills.BloodSpear();
            State.Current.Hero.E = new Skills.ClassSkills.BloodShield();
            State.Current.Hero.R = new Skills.ClassSkills.Ghoul();
        }
    }
}