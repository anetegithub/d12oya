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
    internal sealed class HolyStrike : BSkill, ISkill, IThing
    {
        public HolyStrike()
            : base(30, 0, Scale.Ad, 30, 1.41, 0.3) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Holy Strike"; } }
        public Char Icon { get { return '√'; } }
        public ConsoleColor Color { get { return ConsoleColor.Red; } }
        public ConsoleColor Back { get { return ConsoleColor.Black; } }
        
        //stats
        public Int32 Level { get { return _Level; } }
        public SkillType Type { get { return SkillType.Attack; } }

        //methods
        public void Use(ITargetable Target)
        {
            if (!CanCast())
                return;

            //costing
            HeroRef.Csp -= Cost;

            //dmg
            Int32 Dmg = this.Dmg(Scale.Ad);
            Target.Chp -= Dmg;
            
            //msg
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New(Name, Color, Back);
            Line += " deal ";
            Line += DCLine.New(Dmg.ToString(), Color, Back);
            Line += " holy damage!";
            Temp.State.Current.Chat.Message(Line);
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}