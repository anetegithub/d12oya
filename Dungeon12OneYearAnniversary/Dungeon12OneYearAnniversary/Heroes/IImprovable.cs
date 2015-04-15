using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Heroes
{
    internal interface IImprovable
    {
        Action OnImprove { get; set; }
        void Improve();
    }
}
