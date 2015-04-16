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
    internal sealed class DeadlyPoison : BSkill, ISkill, IThing
    {
        public DeadlyPoison()
            : base(1, 0, Scale.Ad, 0, 0, 1) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Deadly poison"; } }
        public Char Icon { get { return '╤'; } }
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
                Temp.State.Current.Chat.Message(new DrawerLine("You applied a deadly poison to a weapon!", ConsoleColor.Green));

                PressedNow = Input.Pressed;
                Input.OnInput += Input_OnInput;
            }
        }

        private static Boolean AlreadyPoisonedThisPoison;

        IThing AttackManager_OnDealDamage(IThing Target)
        {
            if (State.Random.Next(100) < this.Level)
                (Target as IAttackable).Chp.CleanInt(-1);
            return Target;
        }

        UInt64 PressedNow;
        Int32 Dmged;
        void Input_OnInput()
        {
            if (PressedNow + 120 <= Input.Pressed)
            {
                AttackManager.OnDealDamage -= AttackManager_OnDealDamage;
                Temp.State.Current.Chat.Message(new DrawerLine("Deadly poison on weapons vanished!", ConsoleColor.Green));
                Input.OnInput -= Input_OnInput;
                AlreadyPoisonedThisPoison = false;
            }
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}