using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon12OneYearAnniversary.Objects;
using Dungeon12OneYearAnniversary.Objects.Mapped;
using Dungeon12OneYearAnniversary.IO;
using Dungeon12OneYearAnniversary.Temp;

namespace Dungeon12OneYearAnniversary.Items
{
    internal class BItem : IAttackable
    {
        private void Constructor()
        {
            System.Runtime.Serialization.ObjectIDGenerator a = new System.Runtime.Serialization.ObjectIDGenerator();            

            Chp = 1;
            Chp.SetInt((Int32 Prev) =>
            {
                if (Chp.ToInt() - Prev <= 0)
                {
                    this.WhenDies();
                    return 0;
                }
                else
                    return Prev;
            });
            Mhp = 1;
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
        { Special = EffectDress; }
        private void AdditionalEffectUn(Action EffectUndress)
        { Special2 = EffectUndress; }

        public BItem()
        { Constructor(); }

        public BItem(Int32 Hp, Int32 Sp, Int32 Ap, Int32 Ad, Int32 MinDmg, Int32 MaxDmg, Int32 Armor, Int32 Barrier)
        {
            SetStats(Hp, Sp, Ap, Ad, MinDmg, MaxDmg, Armor, Barrier);
            Constructor();
        }
        public BItem(Int32 Hp, Int32 Sp, Int32 Ap, Int32 Ad, Int32 MinDmg, Int32 MaxDmg, Int32 Armor, Int32 Barrier, Action SpecialEffect)
        {
            SetStats(Hp, Sp, Ap, Ad, MinDmg, MaxDmg, Armor, Barrier);
            AdditionalEffect(SpecialEffect);
            Constructor();
        }
        public BItem(Int32 Hp, Int32 Sp, Int32 Ap, Int32 Ad, Int32 MinDmg, Int32 MaxDmg, Int32 Armor, Int32 Barrier, Action SpecialEffect, Action SpecialEffectUndress)
        {
            SetStats(Hp, Sp, Ap, Ad, MinDmg, MaxDmg, Armor, Barrier);
            AdditionalEffect(SpecialEffect);
            AdditionalEffectUn(SpecialEffectUndress);
            Constructor();
        }

        public BItem(Action SpecialEffect)
        {
            AdditionalEffect(SpecialEffect);
            Constructor();
        }
        public BItem(Action SpecialEffectUndress,Boolean Another)
        {
            AdditionalEffectUn(SpecialEffectUndress);
            Constructor();
        }
        public BItem(Action Dress, Action Undress)
        {
            AdditionalEffect(Dress);
            AdditionalEffectUn(Undress);
            Constructor();
        }

        protected Int32 Hp, Sp, Ap, Ad, MinDmg, MaxDmg, Armor, Barrier;

        private Action Special, Special2;
        

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

        public void Activate()
        {
            State.Current.Msg.Message(new DrawerLine("You equip this item!"));
            Special();
        }
    }
}