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
    internal sealed class Ghoul : BSkill, ISkill, IThing
    {
        public Ghoul()
            : base(5, 1, Scale.Ad, 2, 1.21, 0.97) { }

        //not usable
        public Boolean IsPassable { get { return false; } }
        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Info { get { return String.Empty; } }
        public void Action() { }

        //vision
        public String Name { get { return "Ghoul form"; } }
        public Char Icon { get { return '☺'; } }
        public ConsoleColor Color { get { return ConsoleColor.Green; } }
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

            (Target as IFighter).MinDmg += Dmged;
            (Target as IFighter).MaxDmg += Dmged;
            (Target as IFighter).Ad += Dmged;

            (Target as Heroes.Person).HeroIcon.OnGetChr(gForm);
            (Target as Heroes.Person).HeroColor.OnGet(gColor);
            (Target as Heroes.Person).HeroBack.OnGet(gBack);

            //msg
            DrawerLine Line = new DrawerLine();
            Line.DefaultForegroundColor = HeroRef.Color;
            Line.DefaultBackgroundColor = HeroRef.Back;
            Line += DCLine.New(Name, Color, Back);
            Line += " immprove attack on ";
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
            if (PressedNow + 30 <= Input.Pressed)
            {

                HeroRef.MinDmg -= Dmged;
                HeroRef.MaxDmg -= Dmged;
                HeroRef.Ad -= Dmged;

                HeroRef.HeroIcon.RemoveChr(gForm);
                HeroRef.HeroColor.Remove(gColor);
                HeroRef.HeroBack.Remove(gBack);

                DrawerLine Line = new DrawerLine();
                Line.DefaultForegroundColor = HeroRef.Color;
                Line.DefaultBackgroundColor = HeroRef.Back;
                Line += DCLine.New(Name, Color, Back);
                Line += " completed his action.";
                Temp.State.Current.Chat.Message(Line);
                Input.OnInput -= Input_OnInput;
            }
        }

        Char gForm(Char Prev) { return '☺'; }
        Enum gColor(Enum Prev) { return ConsoleColor.Green; }
        Enum gBack(Enum Prev) { return ConsoleColor.Black; }

        public void LevelUp()
        { base.RunLevelUp(); }
    }
}