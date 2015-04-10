using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Objects.Mapped;
using Dungeon12OneYearAnniversary.IO;

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
    }
}