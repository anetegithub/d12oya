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
    internal sealed class BottleOfElements : BSkill, ISkill, IThing
    {
        public BottleOfElements()
            : base(15, 1, Scale.Ap, 5, 1.21, 0.15) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Bottle Of Elements"; } }
        public Char Icon { get { return 'U'; } }
        public ConsoleColor Color { get { return ConsoleColor.Magenta; } }
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
            Int32 Dmg = this.Dmg(Target);
            Target.Chp -= Dmg;

            //additional (heal)
            Int32 HDmg = (Int32)(Dmg * 1.3);
            if (HeroRef.Chp.Int() < HeroRef.Mhp.Int())
            {
                if (HeroRef.Chp.Int() + HDmg > HeroRef.Mhp.Int())
                    HeroRef.Chp = HeroRef.Mhp;
                else
                    HeroRef.Chp += HDmg;
            }

            //msg
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New(Name, Color, Back);
            Line += " deal ";
            Line += DCLine.New(Dmg.ToString(), Color, Back);
            Line += " damage!";
            Temp.State.Current.Chat.Message(Line);

            for (int i = 0; i < HeroRef.R.Level + 1; i++)
            {
                //dmg
                Dmg = 1;
                Target.Armor -= 1;
                Target.Barrier -= 1;

                //msg
                Line = new DrawerLine();
                Line.DefaultForegroundColor = HeroRef.Color;
                Line.DefaultBackgroundColor = HeroRef.Back;
                Line += DCLine.New(Name, Color, Back);
                Line += " decreases ";
                Line += DCLine.New((Target as IThing).Name, (Target as IThing).Color, (Target as IThing).Back);
                Line += " arm and bar by 1!";
                Temp.State.Current.Chat.Message(Line);
            }

            Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New(Name, Color, Back);
            Line += " heal ";
            Line += DCLine.New(HDmg.ToString(), Color, Back);
            Line += " your hp!";
            Temp.State.Current.Chat.Message(Line);


            if (HeroRef.R.Level > 0)
                new Blessingoftheelements().Use(null);
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}