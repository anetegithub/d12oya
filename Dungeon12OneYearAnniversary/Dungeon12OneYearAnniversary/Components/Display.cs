using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Controls;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Components
{
    internal class Display : BControl
    {
        protected override void DrawTitle()
        {
            DrawerContent con = new DrawerContent();
            con.AppendLine(new DrawerLine("#######################################################################", ConsoleColor.DarkGreen));
            for (int i = 0; i < 30; i++)
                con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#######################################################################", ConsoleColor.DarkGreen));

            DrawerOptions opt = new DrawerOptions();
            opt.Left = 0;
            opt.Top = 0;

            Drawer.Draw(con, opt);
        }

        public override void Draw()
        {
            DrawTitle();
            State.Current.GameField.Draw();
        }

        public override void Handle()
        {
            KeyboardHandler.Handle();
        }
    }
}