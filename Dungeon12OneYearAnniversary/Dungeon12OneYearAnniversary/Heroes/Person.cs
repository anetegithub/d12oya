using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Map;

namespace Dungeon12OneYearAnniversary.Heroes
{
    internal sealed class Person : IThing
    {
        public Field HeroName;
        public Field Class;
        public Field Race;

        public Field Chp, Mhp, Csp, Msp;
        public Field SPColor = ConsoleColor.Blue.ToString(), SPName = "MP";

        public Field Level = 0, Cexp = 0, Mexp = 100;

        public Field MinDmg = 0, MaxDmg = 0;

        public Field Ap = 0, Ad = 0;
        public Field Mdf = 0, Pdf = 0;

        public Field Gold = 0;

        public Field HeroIcon;
        public Field HeroColor;
        public Field HeroBack;

        public List<IThing> Inventory = new List<IThing>();

        //IThing

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