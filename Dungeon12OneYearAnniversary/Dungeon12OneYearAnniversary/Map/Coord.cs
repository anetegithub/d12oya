using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Map
{
    internal struct Coord
    {
        internal Int32 X, Y;

        public static Coord operator +(Coord A, Coord B)
        {
            return new Coord() { X = A.X + B.X, Y = B.Y + A.Y };
        }

        public static Coord operator -(Coord A, Coord B)
        {
            return new Coord() { X = A.X - B.X, Y = B.Y - A.Y };
        }
    }
}