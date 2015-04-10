using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Controls
{
    internal class BControl : IControl
    {
        protected Option _Title = new Option()
        {
            Text = "New Select",
            Color = ConsoleColor.White,
            Back = ConsoleColor.Black
        };

        public Option Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public void Run()
        {            
            Draw();
            Handle();
        }

        public virtual void Handle()
        {
            Console.WriteLine("Not handled");
        }

        public virtual void Draw()
        {
            Console.WriteLine("Not drawed");
        }

        protected virtual void DrawTitle()
        {            
            DrawerOptions opt = new DrawerOptions();
            opt.Left = (Console.WindowWidth / 2) - (Title.Text.Length / 2);
            opt.Top = 1;

            DrawerContent cont = new DrawerContent();
            DrawerLine line = new DrawerLine();
            line.DefaultForegroundColor = Title.Color;
            line.DefaultBackgroundColor = Title.Back;
            line += Title.Text;

            cont.AppendLine(line);

            Drawer.Draw(cont, opt);
        }
    }
}