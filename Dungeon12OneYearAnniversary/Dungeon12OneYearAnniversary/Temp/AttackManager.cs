using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Objects.Monsters;
using Dungeon12OneYearAnniversary.Menu;

namespace Dungeon12OneYearAnniversary.Temp
{
    internal static class AttackManager
    {
        internal static void Attack()
        {
            var HeroPos = State.Current.Hero.Position;
            var NearFields = (from a in State.Current.GameField.Map.Cast<IThing>()
                              where (Math.Abs(a.Position.X - HeroPos.X) <= 1) && (Math.Abs(a.Position.Y - HeroPos.Y) <= 1) && Extensions.GetInterface(a, typeof(IAttackable))
                              select a).ToList();
            NearFields.Remove(State.Current.Hero);
            if (NearFields.Count == 1)
            {
                DealDamage(NearFields[0]);
            }
            else if (NearFields.Count > 1)
            {
                var Pos = HeroPos;
                var Enemy = new List<IThing>();
                while (Pos == HeroPos)
                {
                    State.Current.Chat.Message(new IO.DrawerLine(IO.DCLine.New("Choose attack direction by numpad numbers (5 - you)", ConsoleColor.White, ConsoleColor.Red)));
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.NumPad7: { Pos.X -= 1; Pos.Y -= 1; break; }
                        case ConsoleKey.NumPad8: { Pos.Y -= 1; break; }
                        case ConsoleKey.NumPad9: { Pos.X += 1; Pos.Y -= 1; break; }
                        case ConsoleKey.NumPad4: { Pos.X -= 1; break; }
                        case ConsoleKey.NumPad6: { Pos.X += 1; break; }
                        case ConsoleKey.NumPad1: { Pos.X -= 1; Pos.Y += 1; break; }
                        case ConsoleKey.NumPad2: { Pos.Y += 1; break; }
                        case ConsoleKey.NumPad3: { Pos.X += 1; Pos.Y += 1; break; }
                        default: break;
                    }
                    Enemy = (from a in NearFields where a.Position == Pos select a).ToList();
                    if ((from a in NearFields where a.Position == Pos select a).Count() != 1)
                        Pos = HeroPos;
                }
                DealDamage(Enemy[0]);
            }
        }

        private static void DealDamage(IThing Target)
        {
            Int32 Armor = 0;

            if (Extensions.GetInterface(Target, typeof(IDefender)))
                Armor = (Target as IDefender).Armor.Int();
            else
                Armor = 0;

            Int32 Dmg = State.Current.Hero.Attack(Armor);

            (Target as IAttackable).Chp -= Dmg;

            IO.DrawerLine Line = new IO.DrawerLine();
            Line.DefaultBackgroundColor = ConsoleColor.Black;
            Line.DefaultForegroundColor = ConsoleColor.DarkGreen;
            Line += IO.DCLine.New("You", State.Current.Hero.Color, State.Current.Hero.Back);
            Line += " deal ";
            Line += IO.DCLine.New(Dmg.ToString(), ConsoleColor.White, ConsoleColor.Black);
            Line += " damage!";

            State.Current.Chat.Message(Line);
            State.Current.GameField.Activate(State.Current.Hero.Position);
        }
    }
}