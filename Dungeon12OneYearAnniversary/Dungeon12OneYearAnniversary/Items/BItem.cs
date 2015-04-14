using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Objects.Mapped;
using Dungeon12OneYearAnniversary.Objects.Mapped.Other;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Temp;
using Dungeon12OneYearAnniversary.Items.Equippable;

namespace Dungeon12OneYearAnniversary.Items
{
    internal class BItem : IAttackable, IEquippable
    {
        public BItem()
        { Constructor(); }
        public BItem(Action Dress)
        {
            AdditionalEffect(Dress);
            Constructor();
        }
        public BItem(Action Undress, Boolean B)
        {
            AdditionalEffectUn(Undress);
            Constructor();
        }
        public BItem(Action Dress, Action Undress)
        {
            AdditionalEffect(Dress);
            AdditionalEffectUn(Undress);
            Constructor();
        }
        public BItem(Int32 Hp, Int32 Sp, Int32 Ap, Int32 Ad, Int32 MinDmg, Int32 MaxDmg, Int32 Armor, Int32 Barrier)
        {
            SetStats(Hp, Sp, Ap, Ad, MinDmg, MaxDmg, Armor, Barrier);
            Constructor();
        }
        public BItem(Int32 Hp, Int32 Sp, Int32 Ap, Int32 Ad, Int32 MinDmg, Int32 MaxDmg, Int32 Armor, Int32 Barrier, Action Dress)
        {
            SetStats(Hp, Sp, Ap, Ad, MinDmg, MaxDmg, Armor, Barrier);
            AdditionalEffect(Dress);
            Constructor();
        }
        public BItem(Int32 Hp, Int32 Sp, Int32 Ap, Int32 Ad, Int32 MinDmg, Int32 MaxDmg, Int32 Armor, Int32 Barrier, Action Dress, Action Undress)
        {
            SetStats(Hp, Sp, Ap, Ad, MinDmg, MaxDmg, Armor, Barrier);
            AdditionalEffect(Dress);
            AdditionalEffectUn(Undress);
            Constructor();
        }

        private void Constructor()
        {
            Chp = 1;
            Chp.OnSet((Int32 Prev) =>
            {
                if (Chp.CleanInt() - Prev <= 0)
                {
                    this.WhenDies();
                    return 0;
                }
                else
                    return Prev;                
            });
            Mhp = 1;
            Cost = 1;
        }
        private void SetStats(Int32 Hp, Int32 Sp, Int32 Ap, Int32 Ad, Int32 MinDmg, Int32 MaxDmg, Int32 Armor, Int32 Barrier)
        {
            this.Hp = Hp;
            this.Sp = Sp;
            this.Ap = Ap;
            this.Ad = Ad;
            this.MinDmg = MinDmg;
            this.MaxDmg = MaxDmg;
            this.Armor = Armor;
            this.Barrier = Barrier;
        }
        private void AdditionalEffect(Action EffectDress)
        { OnDress = EffectDress; }
        private void AdditionalEffectUn(Action EffectUndress)
        { OnUndress = EffectUndress; }

        private Int32 Hp, Sp, Ap, Ad, MinDmg, MaxDmg, Armor, Barrier;
        private Action OnDress, OnUndress;
        public Int32 Cost;

        protected Slot _Type = Slot.Belt;
        private String InfoAbout()
        {
            return "";
        }

        public Slot Type { get { return _Type; } }
        public String CompareString 
        { get { return InfoAbout(); } }

        public void Equip()
        {
            if (OnDress != null)
                OnDress();
            State.Current.Hero.Chp += Hp;
            State.Current.Hero.Mhp += Hp;
            State.Current.Hero.Csp += Sp;
            State.Current.Hero.Msp += Sp;
            State.Current.Hero.Ap += Ap;
            State.Current.Hero.Ad += Ad;
            State.Current.Hero.MinDmg += MinDmg;
            State.Current.Hero.MaxDmg += MaxDmg;
            State.Current.Hero.Armor += Armor;
            State.Current.Hero.Barrier += Barrier;
        }
        public void UnEquip()
        {
            if (OnUndress != null)
                OnUndress();
            State.Current.Hero.Chp -= Hp;
            State.Current.Hero.Mhp -= Hp;
            State.Current.Hero.Csp -= Sp;
            State.Current.Hero.Msp -= Sp;
            State.Current.Hero.Ap -= Ap;
            State.Current.Hero.Ad -= Ad;
            State.Current.Hero.MinDmg -= MinDmg;
            State.Current.Hero.MaxDmg -= MaxDmg;
            State.Current.Hero.Armor -= Armor;
            State.Current.Hero.Barrier -= Barrier;
        }

        public Field Chp { get; set; }
        public Field Mhp { get; set; }
        public Int32 Exp { get; set; }

        public void WhenDies()
        {
            DrawerLine Line = new DrawerLine();
            Line.DefaultBackgroundColor = ConsoleColor.DarkGreen;
            Line.DefaultForegroundColor = ConsoleColor.Black;
            if (this.GetType().GetInterface("IThing") != null)
                Line += DCLine.New((this as IThing).Name, (this as IThing).Color, (this as IThing).Back);
            else
                Line += "Item";
            Line += " was broken! ";
            State.Current.Msg.Message(Line);

            if (this.GetType().GetInterface("IThing") != null)
                State.Current.GameField.Map[(this as IThing).Position.X, (this as IThing).Position.Y] = new EThing();

            State.Current.GameField.Draw();
        }

        private void DressUp()
        {
            
        }
        private void Compare()
        { }
        private void Sell()
        {
            var Merch = (from a in State.Current.GameField.Map.Cast<IThing>() where Extensions.GetInterface(a, typeof(IMerch)) select a).ToList();
            if (Merch.Count >= 0)
            {
                State.Current.Msg.Message(new DrawerLine("Nearest trader agreed to buy the item!", ConsoleColor.Green));
                State.Current.Hero.Gold += this.Cost;
                if (this.GetType().GetInterface("IThing") != null)
                    State.Current.GameField.Map[(this as IThing).Position.X, (this as IThing).Position.Y] = new EThing();
                State.Current.GameField.Draw();
            }
            else
            {
                State.Current.Msg.Message(new DrawerLine("Have you seen where be near the seller? You broke the item...", ConsoleColor.Green));
                Chp -= 1;
            }
        }
        private void Back()
        { State.Current.Msg.Message(new DrawerLine("Do not like it? It's ok...", ConsoleColor.Green)); }
        private void Msg()
        {
            DrawerLine Line = new DrawerLine();
            if (this.GetType().GetInterface("IThing") != null)
            {
                Line.DefaultBackgroundColor = (this as IThing).Back;
                Line.DefaultForegroundColor = (this as IThing).Color;
            }
            else
            {
                Line.DefaultBackgroundColor = ConsoleColor.Red;
                Line.DefaultForegroundColor = ConsoleColor.White;
            }

            Line += "1-Compare 2-Dress up 3-Sell 4-Nothing";
            State.Current.Msg.Message(Line);

            Line = new DrawerLine();
            Line.DefaultBackgroundColor = ConsoleColor.Black;
            Line.DefaultForegroundColor = ConsoleColor.Red;

            Line += "What you would do with ";
            if (this.GetType().GetInterface("IThing") != null)
                Line += DCLine.New((this as IThing).Name, (this as IThing).Color, (this as IThing).Back);
            else
                Line += "item";
            State.Current.Msg.Message(Line);
        }
        
        public void Activate()
        {
            Boolean Choosed = false;
            while (!Choosed)
            {
                Msg();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1: { Compare(); Choosed = true; break; }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2: { DressUp(); Choosed = true; break; }
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3: { Sell(); Choosed = true; break; }
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4: { Back(); Choosed = true; break; }
                    default: break;
                }
            }
        }
    }
}
