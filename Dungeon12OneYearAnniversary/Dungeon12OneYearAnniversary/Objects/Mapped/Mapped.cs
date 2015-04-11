using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal static class Mapped
    {
        public static IThing GetRandom()
        {
            if (State.Random.Next(8) == 0)
                switch (State.Random.Next(2))
                {
                    case 0: { return new Rock(); }
                    default: return new Rock();
                }
            else
                switch (State.Random.Next(2))
                {
                    case 0: { return new Gold(); }
                    default: return new Gold();
                }
        }
    }
}