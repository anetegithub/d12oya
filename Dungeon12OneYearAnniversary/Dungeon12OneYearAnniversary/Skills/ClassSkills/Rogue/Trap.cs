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
    internal sealed class Trap : BSkill, ISkill, IThing
    {
        public Trap()
            : base(1, 0, Scale.Ad, 10, 1.21, 0.97) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Set trap"; } }
        public Char Icon { get { return '¤'; } }
        public ConsoleColor Color { get { return ConsoleColor.Magenta; } }
        public ConsoleColor Back { get { return ConsoleColor.Black; } }

        //stats
        public Int32 Level { get { return _Level; } }
        public SkillType Type { get { return SkillType.SelfBuff; } }

        //methods
        public void Use(ITargetable Target)
        {
            Int32 Dmg = this.Dmg();

            var trap = new Objects.Mapped.Trap(Dmg);
            State.Current.Hero.Bag = trap;

            //msg
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += "You set the trap with " + Dmg + " dmg!";
            Temp.State.Current.Chat.Message(Line);
        }

        UInt64 PressedNow;
        Int32 Dmged;

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}