using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Objects.Monsters;

namespace Dungeon12OneYearAnniversary.Temp
{
    internal static class AttackManager
    {
        internal static void Attack()
        {
            var HeroPos = State.Current.Hero.Position;
            var NearFields = (from a in State.Current.GameField.Map.Cast<IThing>()
                              where (Math.Abs(a.Position.X - HeroPos.X) <= 1) && (Math.Abs(a.Position.Y - HeroPos.Y) <= 1)
                              select a).ToList();
            NearFields.Remove(State.Current.Hero);

            if (NearFields.Count == 1)
                if (NearFields[0].GetType().GetInterface("IMonster") != null)
                    DealDamage((IMonster)NearFields[0]);
        }

        private static void DealDamage(IMonster Target)
        {
            Int32 Dmg = State.Random.Next(State.Current.Hero.MinDmg, State.Current.Hero.MaxDmg);
            Target.Chp -= Dmg;

            IO.DrawerLine Line = new IO.DrawerLine();
            Line += IO.DCLine.New("You", State.Current.Hero.Color, State.Current.Hero.Back);
            Line += IO.DCLine.New(" deal ", ConsoleColor.Red, ConsoleColor.Black);
            Line += IO.DCLine.New(Dmg.ToString(), ConsoleColor.White, ConsoleColor.Black);
            Line += IO.DCLine.New(" damage!", ConsoleColor.Red, ConsoleColor.Black);

            State.Current.Msg.Message(Line);
            State.Current.GameField.Activate(State.Current.Hero.Position);
        }
    }
}