using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Heroes
{
    internal sealed class Person
    {
        public Field Name;
        public Field Class;
        public Field Race;

        public Field Chp, Mhp, Csp, Msp;

        public Field SPColor = ConsoleColor.Blue.ToString(), SPName = "MP";

        public Field Level = 0, Cexp = 0, Mexp = 100;

        public Field MinDmg = 0, MaxDmg = 0;

        public Field Ap = 0, Ad = 0;

        public Field Mdf = 0, Pdf = 0;

        public Field Gold = 0;
    }
}