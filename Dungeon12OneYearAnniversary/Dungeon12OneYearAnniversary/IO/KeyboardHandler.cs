using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Menu;

namespace Dungeon12OneYearAnniversary.IO
{
    internal static class KeyboardHandler
    {
        private static ConsoleKeyInfo KeyInfo = new ConsoleKeyInfo();

        public static void Handle()
        {
            KeyInfo = Console.ReadKey(true);
            switch (KeyInfo.Key)
            {
                case ConsoleKey.F1:
                    new Menu.Message().Run();
                    Console.Clear();
                    State.Current.Info.Draw();
                    State.Current.Display.Draw();
                    State.Current.Chat.DrawTitleCustom();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    TimeManager.Steps--;
                    State.Current.GameField.MoveObjects();
                    State.Current.Chat.MessageMin(new DrawerLine("Steps left : " + TimeManager.Steps.ToString(), ConsoleColor.DarkYellow));
                    State.Current.Hero.Position = State.Current.GameField.Move(State.Current.Hero.Position, KeyInfo.Key);
                    State.Current.GameField.Activate(State.Current.Hero.Position);
                    if (State.Random.Next(50) == 0) { State.Current.GameField.DropItem(); }
                    if (State.Random.Next(20) == 0) { State.Current.GameField.DropUsefullItem(); }
                    break;
                case ConsoleKey.A:
                    AttackManager.Attack();
                    break;
                case ConsoleKey.Q:
                    AttackManager.Attack(State.Current.Hero.Q);
                    State.Current.GameField.Activate(State.Current.Hero.Position);
                    break;
                case ConsoleKey.W:
                    AttackManager.Attack(State.Current.Hero.W);
                    State.Current.GameField.Activate(State.Current.Hero.Position);
                    break;
                case ConsoleKey.E:
                    AttackManager.Attack(State.Current.Hero.E);
                    State.Current.GameField.Activate(State.Current.Hero.Position);
                    break;
                case ConsoleKey.R:
                    AttackManager.Attack(State.Current.Hero.R);
                    State.Current.GameField.Activate(State.Current.Hero.Position);
                    break;
                case ConsoleKey.L:
                    InfoMngr.LookAround();
                    break;
                case ConsoleKey.Escape:
                    {
                        Select S = new Select();
                        S.Title.Text = "What are you going to do next?";
                        S.Options = new List<Controls.Option>();
                        S.Options.Add(new Controls.Option()
                        {
                            Color = ConsoleColor.Gray,
                            Back = ConsoleColor.Black,
                            Text = "Resume",
                            CloseAfterClick = true,
                            Click = () =>
                            {
                                Console.Clear();
                                State.Current.Info.Draw();
                                State.Current.Display.Draw();
                                State.Current.Chat.DrawTitleCustom();
                            }
                        });
                        S.Options.Add(new Controls.Option()
                        {
                            Color = ConsoleColor.Gray,
                            Back = ConsoleColor.Black,
                            Text = "Exit & Save",
                            CloseAfterClick = true,
                            Click = () =>
                            {
                                InfoMngr.ExportLogColorless();
                                Environment.Exit(0);
                            }
                        });
                        S.Options.Add(new Controls.Option()
                        {
                            Color = ConsoleColor.Gray,
                            Back = ConsoleColor.Black,
                            Text = "Exi",
                            CloseAfterClick = true,
                            Click = () =>
                            {
                                Environment.Exit(0);
                            }
                        });
                        S.Run();
                        break;
                    }
                default: break;
            }
            Input.Invoke();
            State.Current.Info.Draw();
            Handle();
        }
    }
}