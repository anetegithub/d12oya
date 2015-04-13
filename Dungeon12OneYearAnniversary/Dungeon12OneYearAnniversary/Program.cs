using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

using Dungeon12OneYearAnniversary.Menu;

using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary
{
    class Program
    {
        #region window

        const int SWP_NOSIZE = 0x0001;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static IntPtr MyConsole = GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        #endregion

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 45);
            Console.SetBufferSize(100, 45);
            Console.CursorVisible = false;
            int xpos = 210;
            int ypos = 170;
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);

            Console.Title = "Dungeon 12 One Year Anniversary";

            //Console.WriteLine(Dungeon12OneYearAnniversary.Temp.State.Current.Hero.SPName.GetPtr());
            //Console.WriteLine(Dungeon12OneYearAnniversary.Temp.State.Current.Hero.SPColor.GetPtr());

            Start();

            Console.ReadLine();
        }        

        static void Start()
        {
            Activity.Main.Show();
        }
    }

    public static class Extensions
    {
        public static Boolean Valid(this Char c)
        {
            if (
                c == ',' || c == '\b' || c == '.' || c == '~' || c == '`' || c == '!' || c == '@' || c == '"' || c == '#' || c == '№' || c == '$'
                || c == ';' || c == '%' || c == ':' || c == '^' || c == '*' || c == '\t' || c == '(' || c == ')' || c == '-' || c == '_' || c == '+'
                || c == '=' || c == '{' || c == '}' || c == '[' || c == ']' || c == '\\' || c == '/' || c == '|' || c == '\'' || c == '<' || c == '>')
                return false;
            return true;
        }
    }
};