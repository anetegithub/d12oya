using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.IO
{
    internal static class Input
    {
        private static UInt64 _Pressed = 0;
        public static UInt64 Pressed { get { return _Pressed; } }
        public static void Invoke()
        {
            _Pressed++;
            if (OnInput != null)
                OnInput();
        }

        public static event Action OnInput; 
    }
}
