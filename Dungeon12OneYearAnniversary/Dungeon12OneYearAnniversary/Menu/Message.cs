using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Controls;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Menu
{
    internal sealed class Message : BControl
    {
        protected override void DrawTitle()
        {
            DrawerContent con = new DrawerContent();
            con.AppendLine(new DrawerLine("#######################################################################", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                   Dungeon 12 One Year Anniversary                   #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                              Gameplay:                              #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#          You have 50 steps before next enemy will be respawned      #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#           each your level up steps will decrease by one step        #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#              your mission survive to last boss at 51 level.         #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                              Controls:                              #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                          F1 : This window                           #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                     Up Arrow : Move hero at top                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                    Down Arrow : Move hero to down                   #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                  Left Arrow : Move hero to the left                 #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                 Right Arrow : Move hero to the right                #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                      L : Info about near objects                    #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                      Enter : Take/Activate object                   #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                            A : Hit object                           #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                          Q : Use 1 ability                          #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                          W : Use 2 ability                          #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                          E : Use 3 ability                          #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                          R : Use 4 ability                          #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                         Esc : Exit and Save                         #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                              Good luck!                             #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#                                                                     #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("#######################################################################", ConsoleColor.DarkGreen));

            DrawerOptions opt = new DrawerOptions();
            opt.Left = 50 - con.Lines[0].Chars.Count / 2;
            opt.Top = 19 - con.Lines.Count/2;

            Drawer.Draw(con, opt);
        }

        public override void Draw()
        {
            DrawTitle();
        }

        public override void Handle()
        {
            Console.ReadKey(true);
        }
    }
}