using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;

namespace Dungeon12OneYearAnniversary.IO
{
    public static class Drawer
    {

        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "WriteConsoleOutputW")]
        static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        private struct Coord
        {
            public short X;
            public short Y;

            public Coord(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Explicit)]
        private struct CharUnion
        {
            [FieldOffset(0)]
            public char UnicodeChar;
            [FieldOffset(0)]
            public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct CharInfo
        {
            [FieldOffset(0)]
            public char Char;
            [FieldOffset(2)]
            public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        private static DrawerOptions Options = new DrawerOptions();
        private static DrawerContent Content = new DrawerContent();

        [STAThread]
        public static void Draw()
        {
            SafeFileHandle h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            if (!h.IsInvalid)
            {
                SmallRect rect = Matrix;

                CharInfo[] buf = new CharInfo[(rect.Right - rect.Left) * (rect.Bottom - rect.Top)];

                Int32 Position = 0;

                for (int i = 0; i < (rect.Bottom - rect.Top); i++)
                {
                    Int32 Added = 0;
                    foreach (var symbol in Content.Lines[i].Chars)
                    {
                        buf[Position].Char = symbol.Icon;
                        buf[Position].Attributes = ConvertToAttribute(symbol.Color, symbol.Back);
                        Position++;
                        Added++;
                    }
                    Position += (rect.Right - rect.Left) - Added;
                }

                bool b = WriteConsoleOutput(h, buf,
                      new Coord() { X = (Int16)(rect.Right - rect.Left), Y = (Int16)(rect.Bottom - rect.Top) },
                      new Coord() { X = 0, Y = 0 },
                      ref rect);
            }
        }

        private static SmallRect Matrix
        {
            get
            {
                SmallRect Rect = new SmallRect() { Left = (Int16)Options.Left, Top = (Int16)Options.Top };
                Int16 x = (Int16)Options.Left, y = (Int16)Options.Top, r = 0, b = 0;
                foreach (var l in Content.Lines)
                {
                    if (l.Chars.Count + (Int16)Options.Left > x)
                        x = (Int16)(l.Chars.Count + Options.Left);
                    y++;
                }
                Rect.Right = x;
                Rect.Bottom = y;
                return Rect;
            }
        }

        private static Int16 ConvertToAttribute(ConsoleColor Foreground, ConsoleColor Background)
        {
            Int16 C = (Int16)Foreground;
            switch (Background)
            {
                case ConsoleColor.Blue: { return (Int16)(C | (Int16)0x0010 | (Int16)0x0080); }
                case ConsoleColor.DarkBlue: { return (Int16)(C | (Int16)0x0010); }
                case ConsoleColor.Green: { return (Int16)(C | (Int16)0x0020 | (Int16)0x0080); }
                case ConsoleColor.DarkGreen: { return (Int16)(C | (Int16)0x0020); }
                case ConsoleColor.Red: { return (Int16)(C | (Int16)0x0040 | (Int16)0x0080); }
                case ConsoleColor.DarkRed: { return (Int16)(C | (Int16)0x0040); }
                case ConsoleColor.Yellow: { return (Int16)(C | (Int16)0x0040 | (Int16)0x0020 | (Int16)0x0080); }
                case ConsoleColor.DarkYellow: { return (Int16)(C | (Int16)0x0040 | (Int16)0x0020); }
                case ConsoleColor.Magenta: { return (Int16)(C | (Int16)0x0040 | (Int16)0x0080 | (Int16)0x0010); }
                case ConsoleColor.DarkMagenta: { return (Int16)(C | (Int16)0x0040 | (Int16)0x0010); }
                case ConsoleColor.DarkCyan: { return (Int16)(C | (Int16)0x0020 | (Int16)0x0010); }
                case ConsoleColor.Cyan: { return (Int16)(C | (Int16)0x0020 | (Int16)0x0010 | (Int16)0x0080); }
                case ConsoleColor.Gray: { return (Int16)(C | (Int16)0x0010 | (Int16)0x0020 | (Int16)0x0040); }
                case ConsoleColor.DarkGray: { return (Int16)(C | (Int16)0x0080 | (Int16)0); }
                case ConsoleColor.White: { return (Int16)(C | (Int16)0x0010 | (Int16)0x0020 | (Int16)0x0040 | (Int16)0x0080); }
                default: { return C; }
            }
        }

        [STAThread]
        public static void Draw(DrawerContent Content)
        {
            Drawer.Content = Content;
            Draw();
        }

        [STAThread]
        public static void Draw(DrawerContent Content, DrawerOptions Options)
        {
             Drawer.Content = Content;
             Drawer.Options = Options;
            Draw();
        }
    }
}