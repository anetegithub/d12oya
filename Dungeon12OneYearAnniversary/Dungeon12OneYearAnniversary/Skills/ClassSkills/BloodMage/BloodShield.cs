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
    internal sealed class BloodShield : BSkill, ISkill, IThing
    {
        public BloodShield()
            : base(15, 5, Scale.Ap, 3, 1.36, 0.2) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Blood Shield"; } }
        public Char Icon { get { return '#'; } }
        public ConsoleColor Color { get { return ConsoleColor.DarkRed; } }
        public ConsoleColor Back { get { return ConsoleColor.Black; } }

        //stats
        public Int32 Level { get { return _Level; } }
        public SkillType Type { get { return SkillType.SelfBuff; } }

        //methods
        public void Use(ITargetable Target)
        {
            //costing
            HeroRef.Csp -= Cost;

            //dmg
            Dmged = this.Dmg();

            Target.Armor += Dmged;
            Target.Barrier += Dmged;
            (Target as IMagican).Ap += Dmged;

            //msg
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New(Name, Color, Back);
            Line += " immprove arm,bar,ap on";
            Line += DCLine.New(Dmged.ToString(), Color, Back);
            Line += " !";
            Temp.State.Current.Chat.Message(Line);

            PressedNow = Input.Pressed;
            Input.OnInput += Input_OnInput;
        }

        UInt64 PressedNow;
        Int32 Dmged;
        void Input_OnInput()
        {
            if (PressedNow + 60 <= Input.Pressed)
            {
                HeroRef.Armor -= Dmged;
                HeroRef.Barrier -= Dmged;
                HeroRef.Ap -= Dmged;

                DrawerLine Line = new DrawerLine();
                Line.DefaultForegroundColor = HeroRef.Color;
                Line.DefaultBackgroundColor = HeroRef.Back;
                Line += DCLine.New(Name, Color, Back);
                Line += " completed his action.";
                Temp.State.Current.Chat.Message(Line);
                Input.OnInput -= Input_OnInput;
            }
        }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}