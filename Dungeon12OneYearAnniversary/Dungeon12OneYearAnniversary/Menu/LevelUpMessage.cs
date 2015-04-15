using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Controls;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Skills;

namespace Dungeon12OneYearAnniversary.Menu
{
    internal sealed class LevelUpMessage : BControl
    {
        public String Hit, Sp, Mdmg, MaxDmg;
        protected override void DrawTitle()
        {
            DrawerContent con = new DrawerContent();
            con.AppendLine(new DrawerLine("                  You got a new level of class " + State.Current.Hero.Class.Enum().ToString() + "!             ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                                                                      ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                    You increase your health on" + Hit + "                ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                    and increase your " + State.Current.Hero.SPName.String() + " on" + Sp + "!              ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                                                                      ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                    Minimal damage now equals " + Mdmg + "            ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                         and a maximum of " + MaxDmg + "!             ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                                                                      ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                  Now requires " + TimeManager.Steps + " steps to call a monster!         ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                 Now you can get " + State.Current.Hero.ImpPackMax.ToString() + " more improvements!        ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                                                                      ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("             Select the ability to improve (press button):            ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                      [1] " + State.Current.Hero.Q.Name + "                                    ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                      [2] " + State.Current.Hero.W.Name + "                                    ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                      [3] " + State.Current.Hero.E.Name + "                                    ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                      [4] " + State.Current.Hero.R.Name + "                                    ", ConsoleColor.DarkGreen));
            con.AppendLine(new DrawerLine("                                                                      ", ConsoleColor.DarkGreen));

            DrawerOptions opt = new DrawerOptions();
            opt.Left = 50 - con.Lines[0].Chars.Count / 2;
            opt.Top = 19 - con.Lines.Count / 2;

            Drawer.Draw(con, opt);
        }

        public override void Draw()
        {
            DrawTitle();
        }

        public override void Handle()
        {
            while (true)
            {
                ISkill Skill = null;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1: Skill = State.Current.Hero.Q; break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2: Skill = State.Current.Hero.W; break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3: Skill = State.Current.Hero.E; break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4: Skill = State.Current.Hero.R; break;
                }
                if (Skill != null)
                {
                    IO.DrawerLine linew = new IO.DrawerLine();
                    linew.DefaultForegroundColor = ConsoleColor.Cyan;
                    linew.DefaultBackgroundColor = ConsoleColor.DarkRed;

                    linew += DCLine.New("You", State.Current.Hero.Color, State.Current.Hero.Back);
                    linew += " increase ";
                    linew += DCLine.New(Skill.Name, Skill.Color, Skill.Back);
                    linew += " by one point!";

                    State.Current.Chat.Message(linew);
                    Skill.LevelUp();
                    break;
                }
            }
        }
    }
}