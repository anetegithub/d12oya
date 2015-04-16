using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;

namespace Dungeon12OneYearAnniversary.Skills
{
    internal interface ISkill : IThing
    {
        SkillType Type { get; }
        Int32 Level { get; }
        void Use(ITargetable Target);
        void LevelUp();
    }

    internal enum SkillType { Attack = 0, SelfBuff = 1, Debuff = 2, AoE = 3, Heal = 4, Passive = 5 }
}