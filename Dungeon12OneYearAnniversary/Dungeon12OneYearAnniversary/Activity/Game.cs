using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Components;
using Dungeon12OneYearAnniversary.Game;

namespace Dungeon12OneYearAnniversary.Activity
{
    internal static class Game
    {
        public static void Run()
        {
            State.Current.Info.Run();
            State.Current.Msg.Run();
            State.Current.Display.Run();
        }
    }
}
