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
    internal sealed class HolyLight : BSkill, ISkill, IThing
    {
        public HolyLight()
            : base(15, 1, Scale.Ap, 10, 1.2, 0.3) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Holy light"; } }
        public Char Icon { get { return '▼'; } }
        public ConsoleColor Color { get { return ConsoleColor.Yellow; } }
        public ConsoleColor Back { get { return ConsoleColor.DarkYellow; } }
        
        //stats
        public Int32 Level { get { return _Level; } }
        public SkillType Type { get { return SkillType.Heal; } }

        //methods
        public void Use(ITargetable Target)
        {
            if (!CanCast())
                return;

            //costing
            HeroRef.Csp -= Cost;

            //additional (heal)
            Int32 HDmg = this.Dmg();
            if (HeroRef.Chp.Int() < HeroRef.Mhp.Int())
            {
                if (HeroRef.Chp.Int() + HDmg > HeroRef.Mhp.Int())
                    HeroRef.Chp = HeroRef.Mhp;
                else
                    HeroRef.Chp += HDmg;
            }
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New(Name, Color, Back);
            Line += " heal ";
            Line += DCLine.New(HDmg.ToString(), Color, Back);
            Line += " your hp!";
            Temp.State.Current.Chat.Message(Line);
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}