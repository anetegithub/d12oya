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
    internal sealed class RainbowSpray : BSkill, ISkill, IThing
    {
        public RainbowSpray()
            : base(1, 0, Scale.Ap, 5, 1.37, 0.24) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Rainbow spray"; } }
        public Char Icon { get { return '<'; } }
        public ConsoleColor Color { get { return ConsoleColor.Cyan; } }
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

            for (int i = 0; i < HeroRef.R.Level + 1; i++)
            {
                //dmg
                Int32 Dmg = this.Dmg(Target);
                Target.Chp -= Dmg;

                //msg
                DrawerLine Line = new DrawerLine();
                Line.DefaultForegroundColor = HeroRef.Color;
                Line.DefaultBackgroundColor = HeroRef.Back;
                Line += DCLine.New("Rainbow splatter", Color, Back);
                Line += " deal ";
                Line += DCLine.New(Dmg.ToString(), Color, Back);
                Line += " damage!";
                Temp.State.Current.Chat.Message(Line);
            }

            if (HeroRef.R.Level > 0)
                new Blessingoftheelements().Use(null);
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}