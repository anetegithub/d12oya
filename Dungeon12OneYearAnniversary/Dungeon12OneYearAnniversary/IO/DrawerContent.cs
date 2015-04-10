using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary.IO
{
    public class DrawerContent
    {
        protected List<DrawerLine> _Lines = new List<DrawerLine>();

        public List<DrawerLine> Lines
        {
            get { return _Lines; }
            protected set { _Lines = value; }
        }

        public void Append(DrawerLine Text)
        {
            _Lines[_Lines.Count - 1].Chars.AddRange(Text.Chars);
        }

        public void AppendLine()
        {
            _Lines.Add(new DrawerLine());
        }

        public void AppendLine(DrawerLine S)
        {
            _Lines.Add(S);
        }
    }
}