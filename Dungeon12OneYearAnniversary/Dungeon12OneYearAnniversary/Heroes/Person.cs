using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Map;
using Dungeon12OneYearAnniversary.Skills;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Menu;

namespace Dungeon12OneYearAnniversary.Heroes
{
    internal sealed class Person : IThing, ITargetable, IFighter, IMagican, IImprovable
    {
        public Field HeroName;
        public Field Class;
        public Field Race;

        private Field _Chp;
        public Field Chp { get { return _Chp; } set { _Chp = value; } }
        public Field Mhp { get; set; }
        public Int32 Exp { get; set; }
        public void WhenDies()
        {
            Select s = new Select();
            s.Title = new Controls.Option();
            s.Title.Color = ConsoleColor.Magenta;
            s.Title.Back = ConsoleColor.Black;
            s.Title.Text = "Sorry, u dead.";
            s.Options = new List<Controls.Option>();
            Controls.Option opt = new Controls.Option();
            opt.Text = "No more pain!";
            opt.Click = () =>
            {
                Environment.Exit(0);
            };
            s.Options.Add(opt);
            s.Run();
        }

        public Field Csp, Msp;
        public Field SPColor = ConsoleColor.Blue, SPName = "MP";

        public Field Level = 0, Cexp = 0, Mexp = 100;

        public Field Ad { get; set; }
        public Field MinDmg { get; set; }
        public Field MaxDmg { get; set; }
        public Int32 Attack(Int32 Armor)
        {
            Int32 Dmg = State.Random.Next(MinDmg, MaxDmg);
            Dmg -= (Int32)(Armor * 0.3);
            return Dmg < 0 ? 0 : Dmg;
        }

        public Field Ap { get; set; }
        public Field MDmg { get; set; }
        public Int32 Cast(Int32 Barrier)
        {
            return 0;
        }

        public Field Barrier { get; set; }
        public Field Armor { get; set; }

        public Field Gold = 0;

        public Field HeroIcon;
        public Field HeroColor;
        public Field HeroBack;

        public ISkill Q, W, E, R;

        private Int32 _ImpPackCurrent = 0;
        public Int32 ImpPackCurrent
        { get { return _ImpPackCurrent; } }
        public void ImpPackIncrease()
        { _ImpPackCurrent++; }
        public Int32 ImpPackMax
        { get { return 51-Level.Int(); } }

        public Action OnImprove { get; set; }
        public void Improve() { OnImprove(); }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }

        public String Name
        { get { return this.HeroName; } }
        public String Info
        { get { return "Your hero..."; } }
        public Boolean IsPassable
        { get { return false; } }
        public Char Icon
        { get { return HeroIcon; } }
        public ConsoleColor Color
        { get { return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), HeroColor.Enum().ToString()); } }
        public ConsoleColor Back
        { get { return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), HeroBack.Enum().ToString()); } }
        public void Action()
        { }
    }
}