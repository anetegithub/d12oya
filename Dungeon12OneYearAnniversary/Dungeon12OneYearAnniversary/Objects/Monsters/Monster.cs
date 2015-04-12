using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects.Monsters.Exemples;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Objects.Monsters
{
    internal static class Monster
    {
        public static IThing GetRandom()
        {
            if (State.Random.Next(2) == 0)
                return new Rat();
            else
                return new Zombie();
        }
    }
}