﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Items.Equippable;

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
                switch (State.Random.Next(2))
                {
                    case 0: { return new Gold(); }
                    case 1: { return new Helm(); }
                    default: return new Gold();
                }
        }
    }
}