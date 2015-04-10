using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Heroes;

namespace Dungeon12OneYearAnniversary.Game
{
    internal sealed class State
    {
        private static Lazy<State> _State = new Lazy<State>(() => new State());
        public static State Current
        {
            get { return _State.Value; }
        }

        private State()
        { }

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
    }
}