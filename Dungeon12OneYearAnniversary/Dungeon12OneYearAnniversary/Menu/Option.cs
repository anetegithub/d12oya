using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Menu
{
    internal sealed class Option
    {
        public String Text;
        public Action Click;
        public Boolean CloseAfterClick;
        public ConsoleColor Color = ConsoleColor.Gray;
        public ConsoleColor Back = ConsoleColor.Black;
    }
}
