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
            switch(State.Random.Next(7))
            {
                case 0: return new Rat();
                case 1: return new Zombie();
                case 2: return new Dragon();
                case 3: return new EvilSinger();
                case 4: return new Gnome();
                case 5: return new Necromant();
                case 6: return new Wolf();
                default: return new Rat();
            }
        }
    }
}