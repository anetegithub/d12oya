using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Objects.Mapped;
using Dungeon12OneYearAnniversary.Menu;

namespace Dungeon12OneYearAnniversary.Objects.Monsters.Exemples
{
    internal sealed class BBos : BMonster, IThing
    {
        public BBos()
            : base(100, 1, 1, 1, 2, 1000)
        {
            var This = (this as IAttackable);
            This.Chp.OnSet((Int32 Prev) =>
                {
                    if (this.Chp.Int() - Prev <= 0)
                    {
                        Select s = new Select();
                        s.Title = new Controls.Option();
                        s.Title.Color = ConsoleColor.Magenta;
                        s.Title.Back = ConsoleColor.Black;
                        s.Title.Text = "That's All! You Win! You get " + State.Current.Hero.Gold.Int() + " points! Thanks for playing Dungeon 12 One Year Anniversary!";
                        s.Options = new List<Controls.Option>();
                        Controls.Option opt = new Controls.Option();
                        opt.Text = "Exit";
                        opt.Click = () =>
                        {
                            Environment.Exit(0);
                        };
                        s.Options.Add(opt);
                        return 0;
                    }
                    else
                        return Prev;
                });
        }

        public Coord Position { get; set; }
        public IThing Bag { get; set; }

        public String Name { get { return "Valoran"; } }
        public String Info { get { return "Big boss?"; } }
        public Boolean IsPassable { get { return false; } }
        public Char Icon { get { return '♀'; } }
        public ConsoleColor Color { get { return ConsoleColor.White; } }
        public ConsoleColor Back { get { return ConsoleColor.Black; } }

        public void Action() { Activate(); }
    }
}