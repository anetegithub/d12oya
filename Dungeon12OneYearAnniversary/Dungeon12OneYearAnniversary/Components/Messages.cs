using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Controls;
using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Components
{
    internal sealed class Messages : BControl
    {
        protected override void DrawTitle()
        {
            String s = "#";
            String se = "#";
            for (int i = 0; i < 70; i++)
            {
                s += '#';
                se += ' ';
            }
            se = se.Substring(0, se.Length - 1) + "#";
            s += " ############################";
            se += " #                          #";

            DrawerContent con = new DrawerContent();
            con.AppendLine(new DrawerLine(s, ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine(se, ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine(se, ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine(se, ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine(s, ConsoleColor.DarkGreen));

            DrawerOptions opt = new DrawerOptions();
            opt.Left = 0;
            opt.Top = 33;

            Drawer.Draw(con, opt);
        }

        public new void Run()
        {
            DrawTitle();
            Handle();
        }

        public override void Draw()
        {
            DrawerOptions opt = new DrawerOptions() { Left = 2, Top = 34 };
            DrawerContent con = new DrawerContent();
            foreach (var Line in LastLines)
                con.AppendLine(Line);
            Drawer.Draw(con, opt);

        }

        public void DrawMini()
        {
            DrawerOptions opt = new DrawerOptions() { Left = 74, Top = 34 };
            DrawerContent con = new DrawerContent();
            foreach (var Line in LastMiniLines)
                con.AppendLine(Line);
            Drawer.Draw(con, opt);
        }

        private List<DrawerLine> LastLines = new List<DrawerLine>() { new DrawerLine(), new DrawerLine(), new DrawerLine() };
        private List<DrawerLine> LastMiniLines = new List<DrawerLine>() { new DrawerLine(), new DrawerLine(), new DrawerLine() };

        public void Message(DrawerLine Msg)
        {
            LastLines.Insert(0, Msg);
            LastLines.RemoveRange(3, 1);
            Draw();
        }        

        public void MessageMin(DrawerLine Msg)
        {
            LastMiniLines.Insert(0, Msg);
            LastMiniLines.RemoveRange(3, 1);
            DrawMini();
        }

        public override void Handle()
        { }
    }
}