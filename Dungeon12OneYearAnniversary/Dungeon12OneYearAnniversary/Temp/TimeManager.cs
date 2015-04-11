using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects.Monsters;

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
                    _Steps = 50 - State.Current.Hero.Level.ToInt();
                    if (_Steps == 0)
                        Console.WriteLine("Last boss");
                    else
                    {
                        Int32 X = State.Random.Next(68), Y = State.Random.Next(29);
                        if(State.Current.GameField.Map[X,Y].Name=="Nothing")
                        {
                            State.Current.GameField.Map[X, Y] = Monster.GetRandom();
                            State.Current.GameField.Map[X, Y].Position = new Map.Coord() { X = X, Y = Y };
                        }
                    }
                }
            }
        }
    }
}