using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.IO
{
    public class DrawerLine
    {
        public DrawerLine()
        { }
        public DrawerLine(String String)
        { this.Add(String); }
        public DrawerLine(DCLine DCLine)
        { this.Add(DCLine); }
        public DrawerLine(DrawerChar Char)
        { this.Add(Char); }
        public DrawerLine(String String, ConsoleColor Color)
        {
            this.DefaultForegroundColor = Color;
            this.Add(String);
        }

        private List<DrawerChar> _Chars = new List<DrawerChar>();

        public List<DrawerChar> Chars
        {
            get { return _Chars; }
            protected set { _Chars = value; }
        }

        public static DrawerLine operator +(DrawerLine Line, DrawerChar Char)
        {
            Line._Chars.Add(Char);
            return Line;
        }

        public ConsoleColor DefaultForegroundColor = ConsoleColor.Gray;
        public ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;

        public static DrawerLine operator +(DrawerLine Line, String String)
        {
            foreach (var Char in String)
            {
                Line._Chars.Add(new DrawerChar() { Icon = Char, Color = Line.DefaultForegroundColor, Back = Line.DefaultBackgroundColor });
            }
            return Line;
        }

        public static DrawerLine operator +(DrawerLine Line, DCLine DCLine)
        {
            foreach (var Char in DCLine.Text)
            {
                Line._Chars.Add(new DrawerChar() { Icon = Char, Color = DCLine.Foreground, Back = DCLine.Background });
            }
            return Line;
        }

        public void Add(String String)
        {
            foreach (var Char in String)
            {
                _Chars.Add(new DrawerChar() { Icon = Char, Color = DefaultForegroundColor, Back = DefaultBackgroundColor });
            }
        }

        public void Add(DCLine DCLine)
        {
            foreach (var Char in DCLine.Text)
            {
                _Chars.Add(new DrawerChar() { Icon = Char, Color = DCLine.Foreground, Back = DCLine.Background });
            }
        }

        public void Add(DrawerChar Char)
        {
            _Chars.Add(Char);
        }
    }
}