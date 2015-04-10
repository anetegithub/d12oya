using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.IO
{
    public sealed class DCLine
    {
        public String Text;
        public ConsoleColor Foreground;
        public ConsoleColor Background;

        public static implicit operator DCLine(String S)
        {
            return new DCLine() { Text = S };
        }

        public static DCLine New(String Text, ConsoleColor Foreground, ConsoleColor Background)
        {
            return new DCLine() { Text = Text, Foreground = Foreground, Background = Background };
        }
    }
}