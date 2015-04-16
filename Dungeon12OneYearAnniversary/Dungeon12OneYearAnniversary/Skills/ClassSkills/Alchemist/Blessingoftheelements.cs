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
    internal sealed class Blessingoftheelements : BSkill, ISkill, IThing
    {
        public Blessingoftheelements()
            : base(0, 0, Scale.Ap, 0, 0, 0) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Blessing of the elements"; } }
        public Char Icon { get { return '♀'; } }
        public ConsoleColor Color { get { return ConsoleColor.Magenta; } }
        public ConsoleColor Back { get { return ConsoleColor.Black; } }

        //stats
        public Int32 Level { get { return _Level; } }
        public SkillType Type { get { return SkillType.SelfBuff; } }

        //methods
        public void Use(ITargetable Target)
        {
            String stat = "";
            ConsoleColor ElementColor = ConsoleColor.Black;
            Dmged = 1;

            switch (Element = State.Random.Next(4))
            {
                case 0:
                    {
                        stat = "improve dmg"; ElementColor = ConsoleColor.Red;
                        HeroRef.MinDmg += 1;
                        HeroRef.MaxDmg += 1;
                        PressedNow = Input.Pressed;
                        Input.OnInput += Input_OnInput;
                        break;
                    }
                case 1:
                    {
                        stat = "heal hp"; ElementColor = ConsoleColor.Blue;
                        if (HeroRef.Chp.Int() < HeroRef.Mhp.Int())
                        {
                            if (HeroRef.Chp.Int() + 1 > HeroRef.Mhp.Int())
                                HeroRef.Chp = HeroRef.Mhp;
                            else
                                HeroRef.Chp += 1;
                        }
                        break;
                    }
                case 2:
                    {
                        stat = "add element"; ElementColor = ConsoleColor.Cyan;
                        HeroRef.Msp += 1;
                        HeroRef.Csp += 1;
                        break;
                    }
                case 3:
                    {
                        stat = "add mhp"; ElementColor = ConsoleColor.DarkYellow;
                        HeroRef.Mhp += 1;
                        HeroRef.Chp += 1;
                        break;
                    }
            }

            //msg
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New(Name, Color, Back);
            Line += DCLine.New(stat, ElementColor, ConsoleColor.Black);            
            Line += " !";
            Temp.State.Current.Chat.Message(Line);
        }

        UInt64 PressedNow;
        Int32 Dmged;
        Int32 Element;
        void Input_OnInput()
        {
            if (PressedNow + 15 <= Input.Pressed)
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