using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects.Monsters.Exemples;

namespace Dungeon12OneYearAnniversary.Objects.Monsters
{
    internal static class Monster
    {
        public static IThing GetRandom()
        {
            return new Rat();
        }

    }
}
