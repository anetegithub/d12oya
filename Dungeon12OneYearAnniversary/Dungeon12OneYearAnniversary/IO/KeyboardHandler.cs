using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;

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
                    State.Current.Msg.DrawTitleCustom();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    TimeManager.Steps--;
                    State.Current.GameField.MoveObjects();
                    State.Current.Msg.MessageMin(new DrawerLine("Steps left : " + TimeManager.Steps.ToString(), ConsoleColor.DarkYellow));
                    State.Current.Hero.Position = State.Current.GameField.Move(State.Current.Hero.Position, KeyInfo.Key);
                    State.Current.GameField.Activate(State.Current.Hero.Position);
                    if (State.Random.Next(50) == 0) { State.Current.GameField.DropItem(); }
                    break;
                case ConsoleKey.A:
                    AttackManager.Attack();
                    break;
                default: break;
            }
            State.Current.Info.Draw();
            Input.Invoke();
            Handle();
        }
    }
}