using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Controls;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Components
{
    internal sealed class Messages : BControl
    {
        public Messages()
        {
            LastLines = new List<DrawerLine>();
            LastMiniLines = new List<DrawerLine>();
            for(int i=0;i<10;i++)
            {
                LastLines.Add(new DrawerLine());
                LastMiniLines.Add(new DrawerLine());
            }
        }

        public void DrawTitleCustom()
        {
            DrawTitle();
            Draw();
            DrawMini();
        }

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
            con.AppendLine(new DrawerLine(se, ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine(se, ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine(se, ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine(se, ConsoleColor.DarkGreen));
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

        private List<DrawerLine> LastLines;
        private List<DrawerLine> LastMiniLines;

        public void Message(DrawerLine Msg)
        {
            Logger.Add(Msg);

            for (int i = Msg.Chars.Count; i < 68; i++)
                Msg.Chars.Add(new DrawerChar() { Icon = ' ' });
            LastLines.Insert(0, Msg);
            LastLines.RemoveRange(10, 1);
            Draw();
        }

        public void MessageMin(DrawerLine Msg)
        {
            Logger.Add(Msg);

            LastMiniLines.Insert(0, Msg);
            LastMiniLines.RemoveRange(10, 1);
            DrawMini();
        }

        public override void Handle()
        { }
    }
}