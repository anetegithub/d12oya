using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Skills;
using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Skills.ClassSkills
{
    internal sealed class FireWeapon : BSkill, ISkill, IThing
    {
        public FireWeapon()
            : base(10,2, Scale.Ap, 5, 2.34, 0.43) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Fire weapon"; } }
        public Char Icon { get { return '+'; } }
        public ConsoleColor Color { get { return ConsoleColor.Red; } }
        public ConsoleColor Back { get { return ConsoleColor.Yellow; } }

        //stats
        public Int32 Level { get { return _Level; } }
        public SkillType Type { get { return SkillType.SelfBuff; } }

        //methods
        public void Use(ITargetable Target)
        {
            if (!CanCast())
                return;

            //costing
            HeroRef.Csp -= Cost;
            if (!AlreadyPoisonedThisPoison)
            {
                //dmg
                Dmged = this.Dmg();

                (Target as IFighter).MinDmg += Dmged;
                (Target as IFighter).MaxDmg += Dmged;

                //msg
                Temp.State.Current.Chat.Message(new DrawerLine("You applied a fire to a weapon!", ConsoleColor.Red));


                AlreadyPoisonedThisPoison = true;
                PressedNow = Input.Pressed;
                Input.OnInput += Input_OnInput;
            }
        }

        private static Boolean AlreadyPoisonedThisPoison;

        UInt64 PressedNow;
        Int32 Dmged;
        void Input_OnInput()
        {
            if (PressedNow + 120 <= Input.Pressed)
            {
                HeroRef.MinDmg -= Dmged;
                HeroRef.MaxDmg -= Dmged;

                Temp.State.Current.Chat.Message(new DrawerLine("Fire on weapons vanished!", ConsoleColor.Red));
                Input.OnInput -= Input_OnInput;

                AlreadyPoisonedThisPoison = false;
            }
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}