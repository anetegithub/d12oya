﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Menu;
using Dungeon12OneYearAnniversary.Game;
using Dungeon12OneYearAnniversary.Heroes;
using Dungeon12OneYearAnniversary.Controls;
using Dungeon12OneYearAnniversary.IO;

namespace Dungeon12OneYearAnniversary.Activity
{
    internal static class Main
    {
        private static void Run()
        {
            NewGameMenu();
            SelectRace();
            SelectClass();

            var Hero = State.Current.Hero;
            Hero.Level = 1;

            StatDisplay(Hero);

            Game.Run();
        }

        private static void NewGameMenu()
        {
            Input i = new Input();
            i.Title = new Option() { Text = "Hero name:", Back = ConsoleColor.Black, Color = ConsoleColor.Yellow };
            i.ForegroundColor = ConsoleColor.Magenta;
            i.BackgroundColor = ConsoleColor.Black;
            i.OnEnter = (String Text) =>
            {
                State.Current.Hero.Name = Text.Trim();
            };
            i.Run();
        }

        private static void SelectRace()
        {
            Select sel = new Select();
            sel.Title = new Option() { Text = "Hero class:", Back = ConsoleColor.Black, Color = ConsoleColor.Magenta };
            foreach (Race Value in Enum.GetValues(typeof(Race)).Cast<Race>())
            {
                sel.Options.Add(new Option()
                {
                    Text = Value.ToString(),
                    Color = ConsoleColor.Gray,
                    Back = ConsoleColor.Black,
                    CloseAfterClick = true,
                    Click = () =>
                    {
                        State.Current.Hero.Race = Value.ToString();
                    }
                });
            }
            sel.Run();
        }

        private static void SelectClass()
        {
            Select sel = new Select();
            sel.Title = new Option() { Text = "Hero race:", Back = ConsoleColor.Black, Color = ConsoleColor.Magenta };
            foreach (Class Value in Enum.GetValues(typeof(Class)).Cast<Class>())
            {
                sel.Options.Add(new Option()
                {
                    Text = Value.ToString(),
                    Color = ConsoleColor.Gray,
                    Back = ConsoleColor.Black,
                    CloseAfterClick = true,
                    Click = () =>
                    {
                        State.Current.Hero.Class = Value.ToString();
                    }
                });
            }
            sel.Run();
        }

        public static void Show()
        {
            Select sel = new Select();
            sel.Title = new Option() { Text = "Dungeon 12 One Year Anniversary", Back = ConsoleColor.Black, Color = ConsoleColor.Magenta };
            sel.Options = new List<Option>()
            {
                new Option(){ Text="New game", CloseAfterClick=true, Color= ConsoleColor.Yellow, Back= ConsoleColor.Black, Click=()=>{Run();}},
                new Option(){ Text="Load", CloseAfterClick=true, Color= ConsoleColor.DarkYellow, Back= ConsoleColor.Black, Click=()=>{ LoadMenu();}},
                new Option(){ Text="Exit", CloseAfterClick=true, Color= ConsoleColor.Gray, Back= ConsoleColor.Black, Click=()=>{Environment.Exit(0);}}
            };
            sel.Run();
        }

        private static void LoadMenu()
        {
            Input i = new Input();
            i.Title = new Option() { Text = "Пропишите путь к *.d12oya файлу!", Back = ConsoleColor.Black, Color = ConsoleColor.Magenta };
            i.ForegroundColor = ConsoleColor.Magenta;
            i.BackgroundColor = ConsoleColor.Black;
            i.OnEnter = (String Text) =>
            {
                IO.FileManager.Load(Text);
            };
            i.Run();
        }

        private static void StatDisplay(Person Hero)
        {
            Console.Clear();

            DrawerContent con = new DrawerContent();
            con.AppendLine(new DrawerLine("Hero: " + Hero.Name.ToStr()));
            con.AppendLine(new DrawerLine("Race: " + Hero.Race.ToStr()));
            con.AppendLine(new DrawerLine("Class: " + Hero.Class.ToStr()));
            con.AppendLine(new DrawerLine("Level: " + Hero.Level.ToInt().ToString()));

            DrawerOptions opt = new DrawerOptions();
            Int32 x = 0;
            foreach (var line in con.Lines)
                if (line.Chars.Count > x)
                    x = line.Chars.Count;
            opt.Left = 50 - (x / 2);
            opt.Top = 15 - 3;

            Drawer.Draw(con, opt);
        }
    }
}