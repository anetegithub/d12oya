using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.IO
{
    internal static class Input
    {
        public static void Invoke()
        {
            if (OnInput != null)
                OnInput();
        }

        public static event Action OnInput; 
    }
}
