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
    internal sealed class WeakeningPoison : BSkill, ISkill, IThing
    {
        public WeakeningPoison()
            : base(1, 0, Scale.Ad, 1, 1.24, 0.78) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Weakening poison"; } }
        public Char Icon { get { return ';'; } }
        public ConsoleColor Color { get { return ConsoleColor.Green; } }
        public ConsoleColor Back { get { return ConsoleColor.Black; } }

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
                AlreadyPoisonedThisPoison = true;
                //special effect
                AttackManager.OnDealDamage += AttackManager_OnDealDamage;

                //msg
                Temp.State.Current.Chat.Message(new DrawerLine("You applied a weakening poison to a weapon!", ConsoleColor.Green));

                PressedNow = Input.Pressed;
                Input.OnInput += Input_OnInput;
            }
        }

        private static Boolean AlreadyPoisonedThisPoison;

        IThing AttackManager_OnDealDamage(IThing Target)
        {
            (Target as IDefender).Armor -= Dmg((IDefender)Target);
            (Target as IDefender).Barrier -= Dmg((IDefender)Target);
            Temp.State.Current.Chat.Message(new DrawerLine("Weakening poison reduce target arm and bar!", ConsoleColor.Green));
            return Target;
        }

        UInt64 PressedNow;
        Int32 Dmged;
        void Input_OnInput()
        {
            if (PressedNow + 120 <= Input.Pressed)
            {
                AttackManager.OnDealDamage -= AttackManager_OnDealDamage;
                Temp.State.Current.Chat.Message(new DrawerLine("Weakening poison on weapons vanished!", ConsoleColor.Green));
                Input.OnInput -= Input_OnInput;
                AlreadyPoisonedThisPoison = false;
            }
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}