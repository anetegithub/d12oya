using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;

namespace Dungeon12OneYearAnniversary.Items.Equippable
{
    internal sealed class Helm : BItem, IThing
    {
        public Helm()
            : base()
        { }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }
        public String Name
        { get { return "Helm"; } }
        public String Info
        { get { return "Easy metall heml."; } }
        public Boolean IsPassable
        { get { return false; } }
        public Char Icon
        { get { return '▲'; } }
        public ConsoleColor Color
        { get { return ConsoleColor.DarkGray; } }
        public ConsoleColor Back
        { get { return ConsoleColor.White; } }
        public void Action()
        { Activate(); }
    }
}
