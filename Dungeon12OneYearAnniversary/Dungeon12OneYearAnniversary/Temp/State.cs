using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Heroes;
using Dungeon12OneYearAnniversary.Components;
using Dungeon12OneYearAnniversary.Map;

namespace Dungeon12OneYearAnniversary.Temp
{
    internal sealed class State
    {
        private static Random _Random = new Random();
        public static Random Random
        { get { return _Random; } }

        private State()
        { }

        private static Lazy<State> _State = new Lazy<State>(() => new State());
        public static State Current
        {
            get { return _State.Value; }
        }

        private Lazy<Person> LazyHero = new Lazy<Person>(() => new Person());
        private Person _Hero;
        public Person Hero
        {
            get
            {
                if (!LazyHero.IsValueCreated)
                    _Hero = LazyHero.Value;
                return _Hero;
            }
            set { _Hero = value; }
        }

        public Messages Chat = new Messages();
        public Info Info = new Info();
        public Display Display = new Display();
        public GameField GameField = GameField.New;
    }
}