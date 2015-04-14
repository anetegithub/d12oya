using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Controls;
using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Menu
{
    internal sealed class Control : BControl
    {
        public Action<String> OnEnter;

        private String Text = " ";

        public ConsoleColor ForegroundColor;
        public ConsoleColor BackgroundColor;

        public override void Handle()
        {
            var Key = Console.ReadKey(true);
            while (Key.Key != ConsoleKey.Enter)
            {
                if (Key.KeyChar.Valid())
                    Text += Key.KeyChar;
                else
                    if (Key.KeyChar == '\b' && Text.Length > 0)
                        if (Text.Length >= 2)
                            Text = Text.Substring(0, Text.Length - 2);
                        else
                            Text = "";
                Draw();
                Key = Console.ReadKey(true);
            }
            OnEnter(Text);
        }

        public override void Draw()
        {
            Console.Clear();
            base.DrawTitle();

            DrawerOptions opt = new DrawerOptions();
            opt.Left = (Console.WindowWidth / 2) - (Text.Length / 2);
            opt.Top = (Console.WindowHeight / 2);

            DrawerLine Line = new DrawerLine();

            Line.DefaultForegroundColor = ForegroundColor;
            Line.DefaultBackgroundColor = BackgroundColor;

            Line.Add(Text);
            DrawerContent con=new DrawerContent();
            con.AppendLine(Line);

            Drawer.Draw(con, opt);
        }
    }
}