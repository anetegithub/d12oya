﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Components;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Heroes;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Menu;

namespace Dungeon12OneYearAnniversary.Activity
{
    internal static class Game
    {
        public static void Run()
        {
            InitHero();

            new Menu.Message().Run();
            Console.Clear();
            State.Current.Info.Run();
            State.Current.Chat.Run();
            State.Current.Display.Run();
        }

        private static void InitHero()
        {
            RaceSpecials();
            Mortal();
            Educable();
            State.Current.GameField.Map[35, 15] = State.Current.Hero;
            State.Current.Hero.Position = new Coord() { X = 35, Y = 15 };          
        }

        private static void Mortal()
        {
            State.Current.Hero.Chp.OnSet((Int32 Prev) =>
                {
                    if (State.Current.Hero.Chp.Int() - Prev <= 0)
                    {
                        State.Current.Hero.WhenDies();
                        return 0;
                    }
                    else
                        return Prev;
                });
        }

        private static void Educable()
        {
            State.Current.Hero.Cexp.OnSet((Int32 Prev) =>
                {
                    if (State.Current.Hero.Cexp.Int() + Prev >= State.Current.Hero.Mexp.Int())
                    {
                        IO.DrawerLine linew = new IO.DrawerLine();
                        linew.DefaultForegroundColor = ConsoleColor.Green;
                        linew.DefaultBackgroundColor = ConsoleColor.Yellow;

                        linew += DCLine.New("You", State.Current.Hero.Color, State.Current.Hero.Back);
                        linew += " reach a new level!";

                        State.Current.Chat.Message(linew);
                        State.Current.Hero.Improve();

                        return 0;
                    }
                    else
                        return Prev;
                });
        }

        private static void StartStats(Int32 hp, Int32 mindmg, Int32 maxdmg)
        {
            State.Current.Hero.MinDmg = mindmg;
            State.Current.Hero.MaxDmg = maxdmg;
            State.Current.Hero.Chp = hp;
            State.Current.Hero.Mhp = hp;
        }
        private static void StartVision(Char Icon, ConsoleColor Color, ConsoleColor Back)
        {
            State.Current.Hero.HeroIcon = Icon;
            State.Current.Hero.HeroColor = Color;
            State.Current.Hero.HeroBack = Back;
        }

        private static void RaceSpecials()
        {
            Int32 MinDmg = State.Current.Hero.MinDmg.Int(), MaxDmg = State.Current.Hero.MaxDmg.Int();
            switch ((Race)State.Current.Hero.Race.Enum())
            {
                case Race.Azrai: StartStats(50, 1, 2); ClassSpecials(10, MinDmg + 0, MaxDmg + 1); break;
                case Race.Drow: StartStats(75, 1, 3); ClassSpecials(15, MinDmg + 1, MaxDmg + 2); break;
                case Race.Dwarf: StartStats(150, 1, 4); ClassSpecials(30, MinDmg + 1, MaxDmg + 4); break;
                case Race.Fallen: StartStats(25, 2, 7); ClassSpecials(5, MinDmg + 2, MaxDmg + 7); break;
                case Race.Gnome: StartStats(55, 1, 6); ClassSpecials(11, MinDmg + 1, MaxDmg + 6); break;
                case Race.Kaldorai: StartStats(40, 1, 4); ClassSpecials(8, MinDmg + 1, MaxDmg + 4); break;
                case Race.Orc: StartStats(60, 3, 5); ClassSpecials(12, MinDmg + 3, MaxDmg + 5); break;
                case Race.Troll: StartStats(45, 1, 11); ClassSpecials(7, MinDmg + 1, MaxDmg + 11); break;
                case Race.Undead: StartStats(15, 1, 2); ClassSpecials(3, MinDmg + 1, MaxDmg + 2); break;
                case Race.Human: StartStats(125, 1, 2); ClassSpecials(25, MinDmg + 1, MaxDmg + 2); break;
                default: break;
            }
        }
        private static void ClassSpecials(Int32 PlusHp, Int32 MinDmg, Int32 MaxDmg)
        {
            switch ((Class)State.Current.Hero.Class.Enum())
            {
                case Class.Alchemist: StartVision('@', ConsoleColor.Magenta, ConsoleColor.Yellow); LevelUpRates(PlusHp, 1, MinDmg, MaxDmg); break;
                case Class.Bard: StartVision('♫', ConsoleColor.Yellow, ConsoleColor.Green); LevelUpRates(PlusHp, 1, MinDmg, MaxDmg); break;
                case Class.BloodMage: StartVision('¤', ConsoleColor.Red, ConsoleColor.DarkRed); LevelUpRates(PlusHp, PlusHp, MinDmg, MaxDmg); break;
                case Class.Engineer: StartVision('☼', ConsoleColor.DarkYellow, ConsoleColor.Black); LevelUpRates(PlusHp, 4, MinDmg, MaxDmg); break;
                case Class.Exorcist: StartVision('√', ConsoleColor.Cyan, ConsoleColor.Yellow); LevelUpRates(PlusHp, 2, MinDmg, MaxDmg); break;
                case Class.FireMage: StartVision('‼', ConsoleColor.Red, ConsoleColor.Yellow); LevelUpRates(PlusHp, 10, MinDmg, MaxDmg); break;
                case Class.Monk: StartVision('§', ConsoleColor.Yellow, ConsoleColor.Black); LevelUpRates(PlusHp, 5, MinDmg, MaxDmg); break;
                case Class.Necromancer: StartVision('↨', ConsoleColor.Green, ConsoleColor.DarkMagenta); LevelUpRates(PlusHp, 1, MinDmg, MaxDmg); break;
                case Class.Paladin: StartVision('P', ConsoleColor.Yellow, ConsoleColor.DarkYellow); LevelUpRates(PlusHp, 8, MinDmg, MaxDmg); break;
                case Class.Rogue: StartVision('&', ConsoleColor.Green, ConsoleColor.Black); LevelUpRates(PlusHp, 1, MinDmg, MaxDmg); break;
                case Class.Shaman: StartVision('@', ConsoleColor.Blue, ConsoleColor.DarkGray); LevelUpRates(PlusHp, 25, MinDmg, MaxDmg); break;
                case Class.Warrior: StartVision('☻', ConsoleColor.Red, ConsoleColor.Black); LevelUpRates(PlusHp, 0, MinDmg, MaxDmg); break;
                default: break;
            }
        }

        private static void LevelUpRates(Int32 PlusHp, Int32 PlusSp, Int32 MinDmg, Int32 MaxDmg)
        { State.Current.Hero.OnImprove = OnImproveTemplate(PlusHp, PlusSp, MinDmg, MaxDmg); }
        public static Action OnImproveTemplate(Int32 PlusHp, Int32 PlusSp, Int32 MinDmg, Int32 MaxDmg)
        {
            return () =>
            {
                State.Current.Hero.Chp.CleanInt(State.Current.Hero.Mhp.Int() + PlusHp);
                State.Current.Hero.Mhp.CleanInt(State.Current.Hero.Mhp.Int() + PlusHp);

                State.Current.Hero.Csp.CleanInt(State.Current.Hero.Msp.Int() + PlusSp);
                State.Current.Hero.Msp.CleanInt(State.Current.Hero.Msp.Int() + PlusSp);

                if ((Race)State.Current.Hero.Class.Enum() == Race.Undead)
                {
                    State.Current.Hero.MinDmg.CleanInt(UndeadSpecialMinDmg());
                    State.Current.Hero.MaxDmg.CleanInt(UndeadSpecialMaxDmg());
                }
                else
                {
                    State.Current.Hero.MinDmg.CleanInt(MinDmg);
                    State.Current.Hero.MaxDmg.CleanInt(MaxDmg);
                }

                LevelUpMessage lumsg = new LevelUpMessage();

                lumsg.Hit = PlusHp.ToString();
                lumsg.Sp = PlusSp.ToString();

                lumsg.Mdmg = MinDmg.ToString();
                lumsg.MaxDmg = MaxDmg.ToString();

                lumsg.Run();
            };
        }
        private static Int32 UndeadSpecialMinDmg()
        {
            if(State.Current.Hero.Level.Int()%10==0)
                return State.Current.Hero.MinDmg.Int()+10;
            else
                return 1;
        }
        private static Int32 UndeadSpecialMaxDmg()
        {
            if(State.Current.Hero.Level.Int()%10==0)
                return State.Current.Hero.MaxDmg.Int()+20;
            else
                return 1;
        }

    }
}