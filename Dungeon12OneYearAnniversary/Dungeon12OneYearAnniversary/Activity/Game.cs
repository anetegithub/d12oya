using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Components;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Heroes;

namespace Dungeon12OneYearAnniversary.Activity
{
    internal static class Game
    {
        public static void Run()
        {
            State.Current.GameField.Map[35, 15] = State.Current.Hero;
            State.Current.Hero.Position = new Map.Coord() { X = 35, Y = 15 };
            State.Current.Hero.HeroIcon = '@';
            State.Current.Hero.MinDmg = 1;
            State.Current.Hero.MaxDmg = 2;
            State.Current.Hero.Chp = 100;
            State.Current.Hero.Mhp = 100;
            State.Current.Hero.HeroColor = ConsoleColor.Red.ToString();
            State.Current.Hero.HeroBack = ConsoleColor.Black.ToString();

            new Menu.Message().Run();
            Console.Clear();
            State.Current.Info.Run();
            State.Current.Msg.Run();
            State.Current.Display.Run();
        }
    }
}