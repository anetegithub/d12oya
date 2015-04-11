using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Temp
{
    public static class Logger
    {
        private static List<DrawerLine> Log = new List<DrawerLine>();
        public static void Add(DrawerLine Line)
        { Log.Add(Line); }
    }
}
