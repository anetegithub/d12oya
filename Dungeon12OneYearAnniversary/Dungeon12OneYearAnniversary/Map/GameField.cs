using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Objects.Mapped;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Map
{
    internal class GameField
    {
        private IThing[,] _Map;
        public IThing[,] Map
        {
            get { return _Map; }
            private set { _Map = value; }
        }

        public static GameField New
        {
            get
            {
                GameField Field = new GameField();
                Field.Clear();
                return Field;
            }
        }

        public void Clear()
        {
            _Map = new IThing[69, 30];

            for (int j = 0; j < 30; j++)
                for (int i = 0; i < 69; i++)
                    _Map[i, j] = new EThing();
        }

        public List<String> GetColorless()
        {
            List<String> Lines = new List<string>();

            for (int j = 0; j < 30; j++)
            {
                String Temp = "";
                for (int i = 0; i < 69; i++)
                {
                    Temp += Map[i, j].Icon;
                }
                Lines.Add(Temp);
            }

            return Lines;
        }

        public DrawerContent GetColorfull()
        {
            DrawerContent Content = new DrawerContent();

            for (int j = 0; j < 30; j++)
            {
                DrawerLine Line = new DrawerLine();
                for (int i = 0; i < 69; i++)
                {
                    DrawerChar Char = new DrawerChar();
                    Char.Icon = Map[i, j].Icon;
                    Char.Color = Map[i, j].Color;
                    Char.Back = Map[i, j].Back;

                    Line.Add(Char);
                }
                Content.AppendLine(Line);
            }

            return Content;
        }

        public void Draw()
        {
            Drawer.Draw(GetColorfull(), new DrawerOptions() { Left = 1, Top = 1 });
        }

        public Coord Move(Coord Coord, ConsoleKey Way)
        {
            Coord NewValue = Coord;
            switch (Way)
            {
                case ConsoleKey.UpArrow:
                    {
                        IThing Temp = _Map[Coord.X, Coord.Y];
                        if (Coord.Y > 0 && _Map[Coord.X, Coord.Y - 1].IsPassable)
                        {
                            if (_Map[Coord.X, Coord.Y].Bag != null)
                                _Map[Coord.X, Coord.Y] = _Map[Coord.X, Coord.Y].Bag;
                            else
                                _Map[Coord.X, Coord.Y] = new EThing();
                            _Map[Coord.X, Coord.Y - 1].Bag = _Map[Coord.X, Coord.Y - 1];
                            _Map[Coord.X, Coord.Y - 1] = Temp;
                            NewValue = new Coord() { X = Coord.X, Y = Coord.Y - 1 };
                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        IThing Temp = _Map[Coord.X, Coord.Y];
                        if (Coord.Y < 29 && _Map[Coord.X, Coord.Y + 1].IsPassable)
                        {
                            if (_Map[Coord.X, Coord.Y].Bag != null)
                                _Map[Coord.X, Coord.Y] = _Map[Coord.X, Coord.Y].Bag;
                            else
                                _Map[Coord.X, Coord.Y] = new EThing();
                            _Map[Coord.X, Coord.Y + 1].Bag = _Map[Coord.X, Coord.Y + 1];
                            _Map[Coord.X, Coord.Y + 1] = Temp;
                            NewValue = new Coord() { X = Coord.X, Y = Coord.Y + 1 };
                        }
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        IThing Temp = _Map[Coord.X, Coord.Y];
                        if (Coord.X > 0 && _Map[Coord.X - 1, Coord.Y].IsPassable)
                        {
                            if (_Map[Coord.X, Coord.Y].Bag != null)
                                _Map[Coord.X, Coord.Y] = _Map[Coord.X, Coord.Y].Bag;
                            else
                                _Map[Coord.X, Coord.Y] = new EThing();
                            _Map[Coord.X - 1, Coord.Y].Bag = _Map[Coord.X - 1, Coord.Y];
                            _Map[Coord.X - 1, Coord.Y] = Temp;
                            NewValue = new Coord() { X = Coord.X - 1, Y = Coord.Y };
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        IThing Temp = _Map[Coord.X, Coord.Y];
                        if (Coord.X < 68 && _Map[Coord.X + 1, Coord.Y].IsPassable)
                        {
                            if (_Map[Coord.X, Coord.Y].Bag != null)
                                _Map[Coord.X, Coord.Y] = _Map[Coord.X, Coord.Y].Bag;
                            else
                                _Map[Coord.X, Coord.Y] = new EThing();
                            _Map[Coord.X + 1, Coord.Y].Bag = _Map[Coord.X + 1, Coord.Y];
                            _Map[Coord.X + 1, Coord.Y] = Temp;
                            NewValue = new Coord() { X = Coord.X + 1, Y = Coord.Y };
                        }
                        break;
                    }
            }
            Draw();
            return NewValue;
        }

        public void Activate(Coord CurrentPosition)
        {
            if(CurrentPosition.X-1>=0)
            _Map[CurrentPosition.X - 1, CurrentPosition.Y].Action();
            if (CurrentPosition.X + 1 < 69)
            _Map[CurrentPosition.X + 1, CurrentPosition.Y].Action();
            if (CurrentPosition.Y - 1 >= 0)
            _Map[CurrentPosition.X, CurrentPosition.Y - 1].Action();
            if (CurrentPosition.Y + 1 < 29)
            _Map[CurrentPosition.X, CurrentPosition.Y + 1].Action();
        }

        public void MoveObjects()
        {
            var Monsters = (from a in Map.Cast<IThing>() where a.GetType().GetInterface("IMonster") != null select a).ToList();
            foreach (var Monster in Monsters)
                Monster.Position = Move(Monster.Position, NextStep(Monster.Position));
        }
        private ConsoleKey NextStep(Coord CurrentPosition)
        {
            if (State.Random.Next(2) == 0)
            {
                Coord EnemyPosition = State.Current.Hero.Position;

                if (EnemyPosition.X > CurrentPosition.X)
                    return ConsoleKey.RightArrow;

                if (EnemyPosition.X < CurrentPosition.X)
                    return ConsoleKey.LeftArrow;

                if (EnemyPosition.Y > CurrentPosition.Y)
                    return ConsoleKey.DownArrow;

                if (EnemyPosition.Y < CurrentPosition.Y)
                    return ConsoleKey.UpArrow;

                return ConsoleKey.LeftArrow;
            }
            else
                return (ConsoleKey)State.Random.Next(37, 41);
        }

        public void DropItem()
        {
            Coord Place = new Coord();
            Boolean Droppable=false;
            while (!Droppable)
            {
                Place = new Coord() { X = State.Random.Next(68), Y = State.Random.Next(29) };
                if (Map[Place.X, Place.Y].GetType() == typeof(Objects.Mapped.EThing))
                    Droppable = true;
            }
            DropItem(Place);
        }

        public void DropItem(Coord Place)
        {
            Map[Place.X, Place.Y] = new Objects.Mapped.Gold();
            Map[Place.X, Place.Y].Position = Place;
            Draw();
        }
    }
}