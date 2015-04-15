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
        Int32 Level { get; }
        void Use(ITargetable Target);
        void LevelUp();
    }

    internal static class ISkillExtension
    {
        internal static ISkill Null(this ISkill Skill) { return null; }
    }
}