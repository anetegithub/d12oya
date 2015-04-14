using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects.Monsters;
using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Temp
{
    internal static class TimeManager
    {
        private static Int32 _Steps = 50;
        public static Int32 Steps
        {
            get { return _Steps; }
            set
            {
                _Steps--;
                if (Steps == 0)
                {
                    _Steps = 50 - State.Current.Hero.Level.Int();
                    if (_Steps == 0)
                        Console.WriteLine("Last boss");
                    else
                    {
                        Int32 X = State.Random.Next(68), Y = State.Random.Next(29);
                        if (State.Current.GameField.Map[X, Y].Name == "Nothing")
                        {
                            DrawerLine Line = new DrawerLine();
                            Line.DefaultBackgroundColor = ConsoleColor.Gray;
                            Line.DefaultForegroundColor = ConsoleColor.Black;

                            State.Current.GameField.Map[X, Y] = Monster.GetRandom();
                            Line += DCLine.New(State.Current.GameField.Map[X, Y].Name, State.Current.GameField.Map[X, Y].Color, State.Current.GameField.Map[X, Y].Back);
                            Line += " coming into the lair!";
                            State.Current.Msg.Message(Line);
                            State.Current.GameField.Map[X, Y].Position = new Coord() { X = X, Y = Y };
                        }
                    }
                }
            }
        }
    }
}