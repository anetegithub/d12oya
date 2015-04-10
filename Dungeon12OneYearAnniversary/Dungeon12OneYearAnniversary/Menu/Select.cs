using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Controls;

namespace Dungeon12OneYearAnniversary.Menu
{
    internal class Select : BControl
    {
        public List<Option> Options = new List<Option>();

        private Int32 Index = 0;

        public override void Draw()
        {
            Console.Clear();            
            base.DrawTitle();

            DrawerOptions opt = new DrawerOptions();
            opt.Top = 1;
            foreach (Option o in Options)
            {
                opt.Left = (Console.WindowWidth / 2) - (o.Text.Length / 2);
                opt.Top += 2;

                DrawerLine Line = new DrawerLine();

                if (Options.IndexOf(o) == Index)
                {
                    Line.DefaultBackgroundColor = o.Color;
                    Line.DefaultForegroundColor = o.Back;
                }
                else
                {
                    Line.DefaultForegroundColor = o.Color;
                    Line.DefaultBackgroundColor = o.Back;
                }

                Line += o.Text;

                DrawerContent Content = new DrawerContent();
                Content.AppendLine(Line);

                Drawer.Draw(Content, opt);
            }
        }

        public override void Handle()
        {
            var Key = Console.ReadKey(true);
            switch (Key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (Index > 0)
                            Index--;
                        Run();
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (Index < Options.Count-1)
                            Index++;

                        Run();
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        Options[Index].Click();
                        if (!Options[Index].CloseAfterClick)
                            Run();
                        break;
                    }
                default: Run(); break;
            }
        }
    }


}