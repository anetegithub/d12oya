﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Controls
{
    interface IControl
    {
        void Run();
        void Handle();
        void Draw();
    }
}