﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Objects.Mapped;

namespace Dungeon12OneYearAnniversary.Objects.Monsters.Exemples
{
    internal sealed class Robot : BMonster, IThing
    {
        public Robot()
            : base(0.9, 1.3, 0.1, 2, 3, 37)
        { }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }

        public String Name { get { return "roB-bobob-bot"; } }
        public String Info { get { return "Artificial opponent."; } }
        public Boolean IsPassable { get { return false; } }
        public Char Icon { get { return 'b'; } }
        public ConsoleColor Color { get { return ConsoleColor.Yellow; } }
        public ConsoleColor Back { get { return ConsoleColor.DarkMagenta; } }

        public void Action() { Activate(); }
    }
}