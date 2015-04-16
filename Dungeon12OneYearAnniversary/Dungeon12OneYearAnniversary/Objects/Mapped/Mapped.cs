﻿using System;
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
            if (State.Random.Next(2) == 0)
                switch (State.Random.Next(2))
                {
                    case 0: { return new Rock(); }
                    case 1: { return new Hole(); }
                    default: return new Rock();
                }
            else
                switch (State.Random.Next(7))
                {
                    case 0: { return new Gold(); }
                    case 1: return new ArmorPile();
                    case 2: return new BarrierVase();
                    case 3: return new MagicBook();
                    case 4: return new HealRune();
                    case 5: return new ResourceRune();
                    case 6: return new NewWeapon();
                    default: return new Gold();
                }
        }

        public static IThing GetRandomUsefull()
        {
            if (State.Random.Next(2) == 0)
                return new Gold();
            else
                if (State.Random.Next(2) == 0)
                    return new HealRune();
                else
                    return new ResourceRune();
        }
    }
}