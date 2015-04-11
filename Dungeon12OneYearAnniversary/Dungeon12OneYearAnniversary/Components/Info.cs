using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Heroes;
using Dungeon12OneYearAnniversary.Controls;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Components
{
    internal sealed class Info : BControl
    {
        protected override void DrawTitle()
        {
            DrawerContent con = new DrawerContent();
            con.AppendLine(new DrawerLine("############################", ConsoleColor.DarkGreen));
            for (int i = 0; i < 30; i++)
                con.AppendLine(new DrawerLine("#                          #", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("############################", ConsoleColor.DarkGreen));

            DrawerOptions opt = new DrawerOptions();
            opt.Left = 72;
            opt.Top = 0;

            Drawer.Draw(con, opt);
        }

        public override void Draw()
        {
            DrawTitle();

            DrawerContent Content = new DrawerContent();

            Content.AppendLine(Drawer.Spaces((13) - (State.Current.Hero.HeroName.ToStr().Length / 2)) + State.Current.Hero.HeroName.ToStr(), ConsoleColor.Magenta);

            Content.AppendLine();

            String S = "Race : " + State.Current.Hero.Race.ToStr();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkCyan);
            S = "Class : " + State.Current.Hero.Class.ToStr();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkCyan);

            Content.AppendLine();

            S = "Level : " + State.Current.Hero.Level.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkGray);
            S = "EXP : " + State.Current.Hero.Cexp.ToInt().ToString() + "/" + State.Current.Hero.Mexp.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkGray);

            Content.AppendLine();

            S = "HP : " + State.Current.Hero.Chp.ToInt().ToString() + "/" + State.Current.Hero.Mhp.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.Red);
            S = State.Current.Hero.SPName.ToStr() + " : " + State.Current.Hero.Csp.ToInt().ToString() + "/" + State.Current.Hero.Msp.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, (ConsoleColor)Enum.Parse(typeof(ConsoleColor), State.Current.Hero.SPColor.ToStr()));

            Content.AppendLine();

            S = "Damage";
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkRed);
            S = State.Current.Hero.MinDmg.ToInt().ToString() + "-" + State.Current.Hero.MaxDmg.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkRed);

            Content.AppendLine();

            S = "Attack : " + State.Current.Hero.Ad.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.Cyan);
            S = "Magic : " + State.Current.Hero.Ap.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.Magenta);

            Content.AppendLine();

            S = "Armor : " + State.Current.Hero.Pdf.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkCyan);
            S = "Barier : " + State.Current.Hero.Mdf.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkMagenta);

            Content.AppendLine();

            S = "Fast 1";
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkYellow);
            S = "Health Potion(24)";
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkYellow);
            Content.AppendLine();

            S = "Fast 2";
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkYellow);
            S = "Empty";
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkYellow);
            Content.AppendLine();

            S = "Fast 3";
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkYellow);
            S = "Spell of fire(1)";
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.DarkYellow);
            Content.AppendLine();


            S = "Gold : " + State.Current.Hero.Gold.ToInt().ToString();
            Content.AppendLine(Drawer.Spaces((13) - (S.Length / 2)) + S, ConsoleColor.Yellow);

            Drawer.Draw(Content, new DrawerOptions() { Left = 73, Top = 1 });
        }

        public override void Handle()
        { }
    }
}