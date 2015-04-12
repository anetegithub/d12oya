using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Map;
using Dungeon12OneYearAnniversary.Magic;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Heroes
{
    internal sealed class Person : IThing, ICastable, IFighter, IMagican
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
            Console.WriteLine("Not implemented!");
        }

        public Field Csp, Msp;
        public Field SPColor = ConsoleColor.Blue.ToString(), SPName = "MP";

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


        public Field Barrier {get;set;}
        public Field Armor { get; set; }

        public Field Gold = 0;

        public Field HeroIcon;
        public Field HeroColor;
        public Field HeroBack;

        public List<IThing> Inventory = new List<IThing>();

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
        { get { return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), HeroColor); } }
        public ConsoleColor Back
        { get { return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), HeroBack); } }
        public void Action()
        { }
    }
}