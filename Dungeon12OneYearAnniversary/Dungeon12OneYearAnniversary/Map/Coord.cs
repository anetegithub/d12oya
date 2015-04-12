using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary
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

        public static Boolean operator ==(Coord A, Coord B)
        {
            if (A.X == B.X && A.Y == B.Y)
                return true;
            else
                return false;
        }

        public static Boolean operator !=(Coord A, Coord B)
        {
            return !(A == B);
        }

        public override bool Equals(object obj)
        {
            return this == (Coord)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}