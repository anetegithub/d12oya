using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary
{
    public struct Field
    {
        public Guid Id;
        public void IsId()
        {
            if(this.Id==default(Guid))
                this.Id=Guid.NewGuid();
        }
        private String StrValue;
        private Int32 NumValue;
        private Double DblValue;
        private Char ChrValue;
        private Boolean BolValue;

        private static List<Tuple<Guid, Func<Double, Double>>> GetDbl;
        private static List<Tuple<Guid, Func<Int32, Int32>>> GetNum;
        private static List<Tuple<Guid, Func<String, String>>> GetStr;
        private static List<Tuple<Guid, Func<Char, Char>>> GetChr;
        private static List<Tuple<Guid, Func<Boolean, Boolean>>> GetBol;

        private static List<Tuple<Guid, Func<Double, Double>>> SetDbl;
        private static List<Tuple<Guid, Func<Int32, Int32>>> SetNum;
        private static List<Tuple<Guid, Func<String, String>>> SetStr;
        private static List<Tuple<Guid, Func<Char, Char>>> SetChr;
        private static List<Tuple<Guid, Func<Boolean, Boolean>>> SetBol;

        public void Set(Func<String, String> Act)
        {
            IsId();
            if (SetStr == null)
                SetStr = new List<Tuple<Guid, Func<string, string>>>();
            SetStr.Add(new Tuple<Guid,Func<String,String>>(this.Id,Act));
        }
        public void Set(Func<Double, Double> Act)
        {
            IsId();
            if (SetDbl == null)
                SetDbl = new List<Tuple<Guid, Func<double, double>>>();
            SetDbl.Add(new Tuple<Guid, Func<double, double>>(this.Id, Act));
        }
        public void Set(Func<Boolean, Boolean> Act)
        {
            IsId();
            if (SetBol == null)
                SetBol = new List<Tuple<Guid, Func<bool, bool>>>();
            SetBol.Add(new Tuple<Guid, Func<bool, bool>>(this.Id, Act));
        }
        public void SetChar(Func<Char, Char> Act)
        {
            IsId();
            if (SetChr == null)
                SetChr = new List<Tuple<Guid, Func<char, char>>>();
            SetChr.Add(new Tuple<Guid, Func<char, char>>(this.Id, Act));
        }
        public void SetInt(Func<Int32, Int32> Act)
        {
            IsId();
            if (SetNum == null)
                SetNum = new List<Tuple<Guid, Func<int, int>>>();
            SetNum.Add(new Tuple<Guid, Func<int, int>>(this.Id, Act));
        }

        public void Get(Func<String, String> Act)
        {
            IsId();
            if (GetStr == null)
                GetStr = new List<Tuple<Guid, Func<string, string>>>();
            GetStr.Add(new Tuple<Guid, Func<String, String>>(this.Id, Act));
        }
        public void Get(Func<Double, Double> Act)
        {
            IsId();
            if (GetDbl == null)
                GetDbl = new List<Tuple<Guid, Func<double, double>>>();
            GetDbl.Add(new Tuple<Guid, Func<double, double>>(this.Id, Act));
        }
        public void Get(Func<Boolean, Boolean> Act)
        {
            IsId();
            if (GetBol == null)
                GetBol = new List<Tuple<Guid, Func<bool, bool>>>();
            GetBol.Add(new Tuple<Guid, Func<bool, bool>>(this.Id, Act));
        }
        public void GetChar(Func<Char, Char> Act)
        {
            IsId();
            if (GetChr == null)
                GetChr = new List<Tuple<Guid, Func<char, char>>>();
            GetChr.Add(new Tuple<Guid, Func<char, char>>(this.Id, Act));
        }
        public void GetInt(Func<Int32, Int32> Act)
        {
            IsId();
            if (GetNum == null)
                GetNum = new List<Tuple<Guid, Func<int, int>>>();
            GetNum.Add(new Tuple<Guid, Func<int, int>>(this.Id, Act));
        }

        public void Del(Func<Double, Double> Func)
        {
            Guid This = this.Id;
            if (GetDbl != null)
                GetDbl.Remove(GetDbl.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetDbl != null)
                SetDbl.Remove(GetDbl.First(x => x.Item1 == This && x.Item2 == Func));
        }
        public void Del(Func<String, String> Func)
        {
            Guid This = this.Id;
            if (GetStr != null)
                GetStr.Remove(GetStr.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetStr != null)
                SetStr.Remove(SetStr.First(x => x.Item1 == This && x.Item2 == Func));
        }
        public void Del(Func<Boolean, Boolean> Func)
        {
            Guid This = this.Id;
            if (GetBol != null)
                GetBol.Remove(GetBol.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetBol != null)
                SetBol.Remove(SetBol.First(x => x.Item1 == This && x.Item2 == Func));
        }
        public void DelChar(Func<Char, Char> Func)
        {
            Guid This = this.Id;
            if (GetChr != null)
                GetChr.Remove(GetChr.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetChr != null)
                SetChr.Remove(SetChr.First(x => x.Item1 == This && x.Item2 == Func));
        }
        public void DelInt(Func<Int32, Int32> Func)
        {
            Guid This = this.Id;
            if (GetNum != null)
                GetNum.Remove(GetNum.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetNum != null)
                SetNum.Remove(SetNum.First(x => x.Item1 == This && x.Item2 == Func));
        }

        public static implicit operator Int32(Field F)
        {
            Int32 Value = F.NumValue;
            if (GetNum != null)
                foreach (var Act in (from a in GetNum where a.Item1 == F.Id select a.Item2))
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator String(Field F)
        {
            String Value = F.StrValue;
            if (GetStr != null)
                foreach (var Act in (from a in GetStr where a.Item1 == F.Id select a.Item2))
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator Double(Field F)
        {
            Double Value = F.DblValue;
            if (GetDbl != null)
                foreach (var Act in (from a in GetDbl where a.Item1 == F.Id select a.Item2))
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator Boolean(Field F)
        {
            Boolean Value = F.BolValue;
            if (GetBol != null)
                foreach (var Act in (from a in GetBol where a.Item1 == F.Id select a.Item2))
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator Char(Field F)
        {
            Char Value = F.ChrValue;
            if (GetChr != null)
                foreach (var Act in (from a in GetChr where a.Item1 == F.Id select a.Item2))
                    Value = Act(Value);
            return Value;
        }

        public static implicit operator Field(Int32 i)
        { return new Field() { NumValue = i }; }
        public static implicit operator Field(String s)
        { return new Field() { StrValue = s }; }
        public static implicit operator Field(Double d)
        { return new Field() { DblValue = d }; }
        public static implicit operator Field(Char c)
        { return new Field() { ChrValue = c }; }
        public static implicit operator Field(Boolean b)
        { return new Field() { BolValue = b }; }

        public static Field operator +(Field F, Int32 I)
        {
            if (SetNum != null)
                foreach (var Act in (from a in SetNum where a.Item1 == F.Id select a.Item2))
                    I = Act(I);
            F.NumValue += I;
            return F;
        }
        public static Field operator +(Field F, Double D)
        {
            if (SetDbl != null)
                foreach (var Act in (from a in SetDbl where a.Item1 == F.Id select a.Item2))
                    D = Act(D);
            F.DblValue += D;
            return F;
        }
        public static Field operator +(Field F, String S)
        {
            if (SetStr != null)
                foreach (var Act in (from a in SetStr where a.Item1 == F.Id select a.Item2))
                    S = Act(S);
            F.StrValue += S;
            return F;
        }
        public static Field operator +(Field F, Boolean B)
        {
            if (SetBol != null)
                foreach (var Act in (from a in SetBol where a.Item1 == F.Id select a.Item2))
                    B = Act(B);
            F.BolValue = B;
            return F;
        }
        public static Field operator +(Field F, Char C)
        {
            if (SetChr != null)
                foreach (var Act in (from a in SetChr where a.Item1 == F.Id select a.Item2))
                    C = Act(C);
            F.ChrValue = C;
            return F;
        }

        public static Field operator -(Field F, Int32 I)
        {
            if (SetNum != null)
                foreach (var Act in (from a in SetNum where a.Item1 == F.Id select a.Item2))
                    I = Act(I);
            F.NumValue -= I;
            return F;
        }
        public static Field operator -(Field F, Double D)
        {
            if (SetDbl != null)
                foreach (var Act in (from a in SetDbl where a.Item1 == F.Id select a.Item2))
                    D = Act(D);
            F.DblValue -= D;
            return F;
        }
        public static Field operator -(Field F, String S)
        {
            if (SetStr != null)
                foreach (var Act in (from a in SetStr where a.Item1 == F.Id select a.Item2))
                    S = Act(S);
            F.StrValue = F.StrValue.Replace(S, "");
            return F;
        }
        public static Field operator -(Field F, Boolean B)
        {
            if (SetBol != null)
                foreach (var Act in (from a in SetBol where a.Item1 == F.Id select a.Item2))
                    B = Act(B);
            F.BolValue = B;
            return F;
        }
        public static Field operator -(Field F, Char C)
        {
            if (SetChr != null)
                foreach (var Act in (from a in SetChr where a.Item1 == F.Id select a.Item2))
                    C = Act(C);
            F.ChrValue = C;
            return F;
        }

        public String ToStr()
        { return (String)this; }
        public Double ToDbl()
        { return (Double)this; }
        public Int32 ToInt()
        { return (Int32)this; }
        public Boolean ToBol()
        { return (Boolean)this; }
        public Char ToChr()
        { return (Char)this; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("S=" + this.StrValue + ";I=" + this.NumValue + ";D=" + this.DblValue + ";B=" + this.BolValue + ";C=" + this.ChrValue);
            //sb.AppendLine("S=" + this.StrValue + ";I=" + this.NumValue + ";D=" + this.DblValue + ";B=" + this.BolValue + ";C=" + this.ChrValue);
            return sb.ToString();
        }
    }
}