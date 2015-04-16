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
    internal sealed class BanishEvil : BSkill, ISkill, IThing
    {
        public BanishEvil()
            : base(0, 0, Scale.Ad, 5, 2, 1) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Banish evil"; } }
        public Char Icon { get { return '\\'; } }
        public ConsoleColor Color { get { return ConsoleColor.DarkYellow; } }
        public ConsoleColor Back { get { return ConsoleColor.Black; } }
        
        //stats
        public Int32 Level { get { return _Level; } }
        public SkillType Type { get { return SkillType.Attack; } }

        //methods
        public void Use(ITargetable Target)
        {
            if (!CanCast())
                return;

            if (Target.GetType() != typeof(Objects.Monsters.Exemples.EvilSinger) || Target.GetType() != typeof(Objects.Monsters.Exemples.Necromant) || Target.GetType() != typeof(Objects.Monsters.Exemples.Zombie))
                return;

            //costing
            HeroRef.Csp -= Cost;

            //dmg
            Int32 Dmg = this.Dmg(Target);
            Target.Chp -= Dmg;

            //msg
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New(Name, Color, Back);
            Line += " deal ";
            Line += DCLine.New(Dmg.ToString(), Color, Back);
            Line += " damage!";
            Temp.State.Current.Chat.Message(Line);
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}