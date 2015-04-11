using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Map;

namespace Dungeon12OneYearAnniversary.Objects
{
    internal class BThing : IThing
    {
        public Coord Position { get; set; }

        protected Char _Icon;
        public virtual void SetIcon(Char Icon)
        { _Icon = Icon; }
        public Char Icon
        { get { return _Icon; } }

        protected String _Name;
        public virtual void SetName(String Name)
        { _Name = Name; }
        public String Name
        { get { return _Name; } }

        protected String _Info;
        public virtual void SetInfo(String Info)
        { _Info = Info; }
        public String Info
        { get { return _Info; } }

        protected ConsoleColor _Color;
        public virtual void SetColor(ConsoleColor Color)
        { _Color = Color; }
        public ConsoleColor Color
        { get { return _Color; } }

        protected ConsoleColor _Back;
        public virtual void SetBag(ConsoleColor Back)
        { _Back = Color; }
        public ConsoleColor Back
        { get { return _Back; } }

        protected IThing _Bag;
        public virtual void SetBack(IThing Bag)
        { _Bag = Bag; }
        public IThing Bag
        { get { return _Bag; } set { _Bag = value; } }

        protected Boolean _IsPassable;
        public virtual void SetPassable(Boolean Passable)
        { _IsPassable = Passable; }
        public Boolean IsPassable
        { get { return _IsPassable; } }

        public void Action()
        {
            if (InnerAction == null)
                State.Current.Msg.Message(new DrawerLine("This thing do nothing when action!", ConsoleColor.DarkGray));
            else
                InnerAction();
        }

        protected Action InnerAction;
        public virtual void SetAction(Action Action)
        { InnerAction = Action; }
    }
}