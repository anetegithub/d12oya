﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Objects.Mapped
{
    internal static class Loudmouth
    {
        public static void Yell(DCLine StatName, Int32 _Value, Coord Position, Action IncreaseEffect, DrawerLine DisposeString)
        {
            while (true)
            {
                IO.DrawerLine line = new IO.DrawerLine();
                line.DefaultForegroundColor = ConsoleColor.White;
                line.DefaultBackgroundColor = ConsoleColor.Red;

                line += "It's improvement pack! You taked " + State.Current.Hero.ImpPackCurrent + "/" + State.Current.Hero.ImpPackMax + ", take this one? Y/N";
                State.Current.Msg.Message(line);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        {
                            IO.DrawerLine linew = new IO.DrawerLine();
                            linew.DefaultForegroundColor = ConsoleColor.Cyan;
                            linew.DefaultBackgroundColor = ConsoleColor.DarkRed;

                            linew += DCLine.New("You", State.Current.Hero.Color, State.Current.Hero.Back);
                            linew += "'ve found glandule that increases your ";
                            linew += StatName;
                            linew += " on the ";
                            linew += DCLine.New(_Value.ToString(), ConsoleColor.Red, ConsoleColor.Cyan);
                            linew += "!";

                            State.Current.Msg.Message(linew);

                            IncreaseEffect();

                            State.Current.Hero.ImpPackIncrease();

                            State.Current.GameField.Map[Position.X, Position.Y] = new Objects.Mapped.EThing();
                            State.Current.GameField.Draw();
                            return;
                        }
                    case ConsoleKey.N:
                        {
                            State.Current.Msg.Message(DisposeString);
                            State.Current.GameField.Map[Position.X, Position.Y] = new Objects.Mapped.EThing();
                            State.Current.GameField.Draw();
                            return;
                        }
                }
            }
        }
    }
}