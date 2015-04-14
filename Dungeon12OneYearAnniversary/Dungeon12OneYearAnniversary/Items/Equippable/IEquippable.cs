using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.Items.Equippable
{
    internal interface IEquippable
    {
        Slot Type { get; }
        String CompareString { get; }
        void Equip();
        void UnEquip();
    }

    internal enum Slot { Helm = 0, Chest = 1, Boots = 2, Gloves = 3, Sholder = 4, Belt = 5, Pants = 6, Neck = 7 }
}