using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Dungeon12OneYearAnniversary
{
    public unsafe struct Field
    {
        public Field(Int32 I)
        {
            NumValue = I;
            DblValue = 0;
            ChrValue = (Char)0;
            BolValue = false;
            StrIndex = 0;
        }
        public Field(String S)
        {
            NumValue = 0;
            DblValue = 0;
            ChrValue = (Char)0;
            BolValue = false;

            if (StrValue == null)
                StrValue = new Dictionary<Int32, string>();
            StrIndex = StringIndexes++;
            StrValue.Add(StrIndex, S);
        }
        public Field(Double D)
        {
            NumValue = 0;
            DblValue = D;
            ChrValue = (Char)0;
            BolValue = false;
            StrIndex = 0;
        }
        public Field(Char C)
        {
            NumValue = 0;
            DblValue = 0;
            ChrValue = C;
            BolValue = false;
            StrIndex = 0;
        }
        public Field(Boolean B)
        {
            NumValue = 0;
            DblValue = 0;
            ChrValue = (Char)0;
            BolValue = B;
            StrIndex = 0;
        }

        private static Int32 StringIndexes=0;
        private static Dictionary<Int32, String> StrValue;
        private Int32 NumValue;
        private Double DblValue;
        private Char ChrValue;
        private Boolean BolValue;
        private Int32 StrIndex;

        private static List<Tuple<IntPtr, Func<Double, Double>>> GetDbl;
        private static List<Tuple<IntPtr, Func<Int32, Int32>>> GetNum;
        private static List<Tuple<IntPtr, Func<String, String>>> GetStr;
        private static List<Tuple<IntPtr, Func<Char, Char>>> GetChr;
        private static List<Tuple<IntPtr, Func<Boolean, Boolean>>> GetBol;

        private static List<Tuple<IntPtr, Func<Double, Double>>> SetDbl;
        private static List<Tuple<IntPtr, Func<Int32, Int32>>> SetNum;
        private static List<Tuple<IntPtr, Func<String, String>>> SetStr;
        private static List<Tuple<IntPtr, Func<Char, Char>>> SetChr;
        private static List<Tuple<IntPtr, Func<Boolean, Boolean>>> SetBol;

        public void Set(Func<String, String> Act)
        {
            if (SetStr == null)
                SetStr = new List<Tuple<IntPtr, Func<string, string>>>();
            SetStr.Add(new Tuple<IntPtr, Func<string, string>>(this.GetPtr(), Act));
        }
        public void Set(Func<Double, Double> Act)
        {

            if (SetDbl == null)
                SetDbl = new List<Tuple<IntPtr, Func<double, double>>>();
            SetDbl.Add(new Tuple<IntPtr, Func<double, double>>(this.GetPtr(), Act));
        }
        public void Set(Func<Boolean, Boolean> Act)
        {
            if (SetBol == null)
                SetBol = new List<Tuple<IntPtr, Func<bool, bool>>>();
            SetBol.Add(new Tuple<IntPtr, Func<bool, bool>>(this.GetPtr(), Act));
        }
        public void SetChar(Func<Char, Char> Act)
        {

            if (SetChr == null)
                SetChr = new List<Tuple<IntPtr, Func<char, char>>>();
            SetChr.Add(new Tuple<IntPtr, Func<char, char>>(this.GetPtr(), Act));
        }
        public void SetInt(Func<Int32, Int32> Act)
        {

            if (SetNum == null)
                SetNum = new List<Tuple<IntPtr, Func<int, int>>>();
            SetNum.Add(new Tuple<IntPtr, Func<int, int>>(this.GetPtr(), Act));
        }

        public void Get(Func<String, String> Act)
        {
            if (GetStr == null)
                GetStr = new List<Tuple<IntPtr, Func<string, string>>>();
            GetStr.Add(new Tuple<IntPtr, Func<string, string>>(this.GetPtr(), Act));
        }
        public void Get(Func<Double, Double> Act)
        {

            if (GetDbl == null)
                GetDbl = new List<Tuple<IntPtr, Func<double, double>>>();
            GetDbl.Add(new Tuple<IntPtr, Func<double, double>>(this.GetPtr(), Act));
        }
        public void Get(Func<Boolean, Boolean> Act)
        {
            if (GetBol == null)
                GetBol = new List<Tuple<IntPtr, Func<bool, bool>>>();
            GetBol.Add(new Tuple<IntPtr, Func<bool, bool>>(this.GetPtr(), Act));
        }
        public void GetChar(Func<Char, Char> Act)
        {

            if (GetChr == null)
                GetChr = new List<Tuple<IntPtr, Func<char, char>>>();
            GetChr.Add(new Tuple<IntPtr, Func<char, char>>(this.GetPtr(), Act));
        }
        public void GetInt(Func<Int32, Int32> Act)
        {

            if (GetNum == null)
                GetNum = new List<Tuple<IntPtr, Func<int, int>>>();
            GetNum.Add(new Tuple<IntPtr, Func<int, int>>(this.GetPtr(), Act));
        }

        public void Del(Func<Double, Double> Func)
        {
            IntPtr This = this.GetPtr();
            if (GetDbl != null)
                GetDbl.Remove(GetDbl.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetDbl != null)
                SetDbl.Remove(GetDbl.First(x => x.Item1 == This && x.Item2 == Func));
        }
        public void Del(Func<String, String> Func)
        {
            IntPtr This = this.GetPtr();
            if (GetStr != null)
                GetStr.Remove(GetStr.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetStr != null)
                SetStr.Remove(SetStr.First(x => x.Item1 == This && x.Item2 == Func));
        }
        public void Del(Func<Boolean, Boolean> Func)
        {
            IntPtr This = this.GetPtr();
            if (GetBol != null)
                GetBol.Remove(GetBol.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetBol != null)
                SetBol.Remove(SetBol.First(x => x.Item1 == This && x.Item2 == Func));
        }
        public void DelChar(Func<Char, Char> Func)
        {
            IntPtr This = this.GetPtr();
            if (GetChr != null)
                GetChr.Remove(GetChr.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetChr != null)
                SetChr.Remove(SetChr.First(x => x.Item1 == This && x.Item2 == Func));
        }
        public void DelInt(Func<Int32, Int32> Func)
        {
            IntPtr This = this.GetPtr();
            if (GetNum != null)
                GetNum.Remove(GetNum.First(x => x.Item1 == This && x.Item2 == Func));
            if (SetNum != null)
                SetNum.Remove(SetNum.First(x => x.Item1 == This && x.Item2 == Func));
        }

        public static implicit operator Int32(Field F)
        {
            Int32 Value = F.NumValue;
            if (GetNum != null)
                foreach (var Act in (from a in GetNum where a.Item1 == F.GetPtr() select a.Item2))
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator String(Field F)
        {
            String Value = StrValue[F.StrIndex];
            if (GetStr != null)
                foreach (var Act in (from a in GetStr where a.Item1 == F.GetPtr() select a.Item2))
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator Double(Field F)
        {
            Double Value = F.DblValue;
            if (GetDbl != null)
                foreach (var Act in (from a in GetDbl where a.Item1 == F.GetPtr() select a.Item2))
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator Boolean(Field F)
        {
            Boolean Value = F.BolValue;
            if (GetBol != null)
                foreach (var Act in (from a in GetBol where a.Item1 == F.GetPtr() select a.Item2))
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator Char(Field F)
        {
            Char Value = F.ChrValue;
            if (GetChr != null)
                foreach (var Act in (from a in GetChr where a.Item1 == F.GetPtr() select a.Item2))
                    Value = Act(Value);
            return Value;
        }

        public static implicit operator Field(Int32 I)
        { return new Field(I); }
        public static implicit operator Field(String S)
        { return new Field(S); }
        public static implicit operator Field(Double D)
        { return new Field(D); }
        public static implicit operator Field(Char C)
        { return new Field(C); }
        public static implicit operator Field(Boolean B)
        { return new Field(B); }

        public static Field operator +(Field F, Int32 I)
        {
            if (SetNum != null)
                foreach (var Act in (from a in SetNum where a.Item1 == F.GetPtr() select a.Item2))
                    I = Act(I);
            F.NumValue += I;
            return F;
        }
        public static Field operator +(Field F, Double D)
        {
            if (SetDbl != null)
                foreach (var Act in (from a in SetDbl where a.Item1 == F.GetPtr() select a.Item2))
                    D = Act(D);
            F.DblValue += D;
            return F;
        }
        public static Field operator +(Field F, String S)
        {
            if (SetStr != null)
                foreach (var Act in (from a in SetStr where a.Item1 == F.GetPtr() select a.Item2))
                    S = Act(S);
            StrValue[F.StrIndex] = S;
            return F;
        }
        public static Field operator +(Field F, Boolean B)
        {
            if (SetBol != null)
                foreach (var Act in (from a in SetBol where a.Item1 == F.GetPtr() select a.Item2))
                    B = Act(B);
            F.BolValue = B;
            return F;
        }
        public static Field operator +(Field F, Char C)
        {
            if (SetChr != null)
                foreach (var Act in (from a in SetChr where a.Item1 == F.GetPtr() select a.Item2))
                    C = Act(C);
            F.ChrValue = C;
            return F;
        }

        public static Field operator -(Field F, Int32 I)
        {
            if (SetNum != null)
                foreach (var Act in (from a in SetNum where a.Item1 == F.GetPtr() select a.Item2))
                    I = Act(I);
            F.NumValue -= I;
            return F;
        }
        public static Field operator -(Field F, Double D)
        {
            if (SetDbl != null)
                foreach (var Act in (from a in SetDbl where a.Item1 == F.GetPtr() select a.Item2))
                    D = Act(D);
            F.DblValue -= D;
            return F;
        }
        public static Field operator -(Field F, String S)
        {
            if (SetStr != null)
                foreach (var Act in (from a in SetStr where a.Item1 == F.GetPtr() select a.Item2))
                    S = Act(S);
            StrValue[F.StrIndex] = StrValue[F.StrIndex].Replace(S, "");
            return F;
        }
        public static Field operator -(Field F, Boolean B)
        {
            if (SetBol != null)
                foreach (var Act in (from a in SetBol where a.Item1 == F.GetPtr() select a.Item2))
                    B = Act(B);
            F.BolValue = B;
            return F;
        }
        public static Field operator -(Field F, Char C)
        {
            if (SetChr != null)
                foreach (var Act in (from a in SetChr where a.Item1 == F.GetPtr() select a.Item2))
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
            sb.AppendLine("{" + StrValue[StrIndex] + "}[" + this.NumValue + "]~" + this.DblValue + "~!" + this.BolValue + "!'" + this.ChrValue + "'");
            return sb.ToString();
        }

        public IntPtr GetPtr()
        {
            unsafe
            {
                fixed (Field* F = &this)
                    return (IntPtr)F;
            }
        }
    }
}