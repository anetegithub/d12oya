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
    internal sealed class BrewPotion : BSkill, ISkill, IThing
    {
        public BrewPotion()
            : base(1, 1, Scale.Ap, 4, 1.21, 0.79) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Brew potion"; } }
        public Char Icon { get { return '⌂'; } }
        public ConsoleColor Color { get { return ConsoleColor.Blue; } }
        public ConsoleColor Back { get { return ConsoleColor.Red; } }
        
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

            //additional (heal and restore sp)
            Int32 HDmg = this.Dmg();
            if (HeroRef.Chp.Int() < HeroRef.Mhp.Int())
            {
                if (HeroRef.Chp.Int() + HDmg > HeroRef.Mhp.Int())
                    HeroRef.Chp = HeroRef.Mhp;
                else
                    HeroRef.Chp += HDmg;
            }
            if (HeroRef.Csp.Int() < HeroRef.Msp.Int())
            {
                if (HeroRef.Csp.Int() + HDmg > HeroRef.Msp.Int())
                    HeroRef.Csp = HeroRef.Msp;
                else
                    HeroRef.Csp += HDmg;
            }
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New(Name, Color, Back);
            Line += " heal and restore ";
            Line += DCLine.New(HDmg.ToString(), Color, Back);
            Line += " elements!";
            Temp.State.Current.Chat.Message(Line);

            if (HeroRef.R.Level > 0)
                new Blessingoftheelements().Use(null);
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}