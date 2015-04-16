﻿using System;
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
    internal sealed class PillarOfLight : BSkill, ISkill, IThing
    {
        public PillarOfLight()
            : base(25, 2, Scale.Ap, 10, 1.21, 0.4) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Pillar of Light"; } }
        public Char Icon { get { return '█'; } }
        public ConsoleColor Color { get { return ConsoleColor.Yellow; } }
        public ConsoleColor Back { get { return ConsoleColor.DarkYellow; } }

        //stats
        public Int32 Level { get { return _Level; } }
        public SkillType Type { get { return SkillType.AoE; } }

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

            //msg
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New((Target as IThing).Name, (Target as IThing).Color, (Target as IThing).Back);
            Line += " take ";
            Line += DCLine.New(Dmg.ToString(), Color, Back);
            Line += " damage from ";
            Line += DCLine.New(Name, Color, Back);
            Line += "!";
            Temp.State.Current.Chat.Message(Line);
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}