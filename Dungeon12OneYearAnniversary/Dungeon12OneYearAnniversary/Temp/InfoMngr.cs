using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Dungeon12OneYearAnniversary.Objects;

namespace Dungeon12OneYearAnniversary.Temp
{
    internal static class InfoMngr
    {
        public static void LookAround()
        {
            var HeroPos = State.Current.Hero.Position;
            var NearFields = (from a in State.Current.GameField.Map.Cast<IThing>()
                              where (Math.Abs(a.Position.X - HeroPos.X) <= 2) && (Math.Abs(a.Position.Y - HeroPos.Y) <= 2) && Extensions.GetInterface(a, typeof(IAttackable))
                              select a).ToList();
            NearFields.Remove(State.Current.Hero);
            foreach(var Thing in NearFields)
            {
                if(Thing.GetType()!=typeof(Objects.Mapped.EThing))
                {
                    var line=IO.DCLine.New(Thing.Info,Thing.Color,Thing.Back);
                    State.Current.Chat.Message(new IO.DrawerLine(line));
                }
            }
        }

        public static void ExportLogColorless()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var Line in Logger.GetLog())
            {
                String temp = "";
                foreach(var ch in Line.Chars)
                {
                    temp += ch.Icon;
                }
                sb.AppendLine(temp);
            }
            File.WriteAllText(DateTime.Now.ToShortTimeString().Replace(":","_") + ".txt", sb.ToString());

        }

        public static void ExportLogColorfull()
        {

        }
    }
}
