using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary
{
    public struct Field
    {
        private String StrValue;
        private Int32 NumValue;
        private Double DblValue;
        private Char ChrValue;
        private Boolean BolValue;

        private List<Func<Double, Double>> GetDbl;
        private List<Func<Int32, Int32>> GetNum;
        private List<Func<String, String>> GetStr;
        private List<Func<Char, Char>> GetChr;
        private List<Func<Boolean, Boolean>> GetBol;

        private List<Func<Double, Double>> SetDbl;
        private List<Func<Int32, Int32>> SetNum;
        private List<Func<String, String>> SetStr;
        private List<Func<Char, Char>> SetChr;
        private List<Func<Boolean, Boolean>> SetBol;

        public void Set(Func<String, String> Act)
        {
            if (SetStr == null)
                SetStr = new List<Func<string, string>>();
            SetStr.Add(Act);
        }
        public void Set(Func<Double, Double> Act)
        {
            if (SetDbl == null)
                SetDbl = new List<Func<double, double>>();
            SetDbl.Add(Act);
        }
        public void Set(Func<Boolean, Boolean> Act)
        {
            if (SetBol == null)
                SetBol = new List<Func<bool, bool>>();
            SetBol.Add(Act);
        }
        public void SetChar(Func<Char, Char> Act)
        {
            if (SetChr == null)
                SetChr = new List<Func<char, char>>();
            SetChr.Add(Act);
        }
        public void SetInt(Func<Int32, Int32> Act)
        {
            if (SetNum == null)
                SetNum = new List<Func<int, int>>();
            this.SetNum.Add(Act);
        }

        public void Get(Func<Double, Double> Act)
        {
            if (GetDbl == null)
                GetDbl = new List<Func<double, double>>();
            GetDbl.Add(Act);
        }
        public void Get(Func<String, String> Act)
        {
            if (GetStr == null)
                GetStr = new List<Func<string, string>>();
            GetStr.Add(Act);
        }
        public void Get(Func<Boolean, Boolean> Act)
        {
            if (GetBol == null)
                GetBol = new List<Func<bool, bool>>();
            GetBol.Add(Act);
        }
        public void GetChar(Func<Char, Char> Act)
        {
            if (GetChr == null)
                GetChr = new List<Func<char, char>>();
            GetChr.Add(Act);
        }
        public void GetInt(Func<Int32, Int32> Act)
        {
            if (GetNum == null)
                GetNum = new List<Func<int, int>>();
            GetNum.Add(Act);
        }

        public void Del(Func<Double, Double> Func)
        {
            if (GetDbl != null)
                GetDbl.Remove(Func);
            if (SetDbl != null)
                SetDbl.Remove(Func);
        }
        public void Del(Func<String, String> Func)
        {
            if (GetStr != null)
                GetStr.Remove(Func);
            if (SetStr != null)
                SetStr.Remove(Func);
        }
        public void Del(Func<Boolean, Boolean> Func)
        {
            if (GetBol != null)
                GetBol.Remove(Func);
            if (SetBol != null)
                SetBol.Remove(Func);
        }
        public void DelChar(Func<Char, Char> Func)
        {
            if (GetChr != null)
                GetChr.Remove(Func);
            if (SetChr != null)
                SetChr.Remove(Func);
        }
        public void DelInt(Func<Int32, Int32> Func)
        {
            if (GetNum != null)
                GetNum.Remove(Func);
            if (SetNum != null)
                SetNum.Remove(Func);
        }

        public static implicit operator Int32(Field F)
        {
            Int32 Value = F.NumValue;
            if (F.GetNum != null)
                foreach (var Act in F.GetNum)
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator String(Field F)
        {
            String Value = F.StrValue;
            if (F.GetStr != null)
                foreach (var Act in F.GetStr)
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator Double(Field F)
        {
            Double Value = F.DblValue;
            if (F.GetDbl != null)
                foreach (var Act in F.GetDbl)
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator Boolean(Field F)
        {
            Boolean Value = F.BolValue;
            if (F.GetBol != null)
                foreach (var Act in F.GetBol)
                    Value = Act(Value);
            return Value;
        }
        public static implicit operator Char(Field F)
        {
            Char Value = F.ChrValue;
            if (F.GetChr != null)
                foreach (var Act in F.GetChr)
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
            if (F.SetNum != null)
                foreach (var Act in F.SetNum)
                    I = Act(I);
            F.NumValue += I;
            return F;
        }
        public static Field operator +(Field F, Double D)
        {
            if (F.SetDbl != null)
                foreach (var Act in F.SetDbl)
                    D = Act(D);
            F.DblValue += D;
            return F;
        }
        public static Field operator +(Field F, String S)
        {
            if (F.SetStr != null)
                foreach (var Act in F.SetStr)
                    S = Act(S);
            F.StrValue += S;
            return F;
        }

        public static Field operator -(Field F, Int32 I)
        {
            if (F.SetNum != null)
                foreach (var Act in F.SetNum)
                    I = Act(I);
            F.NumValue -= I;
            return F;
        }
        public static Field operator -(Field F, Double D)
        {
            if (F.SetDbl != null)
                foreach (var Act in F.SetDbl)
                    D = Act(D);
            F.DblValue -= D;
            return F;
        }
        public static Field operator -(Field F, String S)
        {
            if (F.SetStr != null)
                foreach (var Act in F.SetStr)
                    S = Act(S);
            F.StrValue.Replace(S, "");
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