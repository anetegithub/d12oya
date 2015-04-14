using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon12OneYearAnniversary
{
    public struct Field
    {
        public Field(Int32 I)
        {
            IntValue = I;
            DblValue = 0;
            ChrValue = (Char)0;
            BolValue = false;
            _Id = Identificator++;
        }
        public Field(String S)
        {
            IntValue = 0;
            DblValue = 0;
            ChrValue = (Char)0;
            BolValue = false;
            _Id = Identificator++;

            if (StrValue == null)
                StrValue = new Dictionary<UInt64, string>();
            StrValue.Add(Id, S);
        }
        public Field(Double D)
        {
            IntValue = 0;
            DblValue = D;
            ChrValue = (Char)0;
            BolValue = false;
            _Id = Identificator++;
        }
        public Field(Char C)
        {
            IntValue = 0;
            DblValue = 0;
            ChrValue = C;
            BolValue = false;
            _Id = Identificator++;
        }
        public Field(Boolean B)
        {
            IntValue = 0;
            DblValue = 0;
            ChrValue = (Char)0;
            BolValue = B;
            _Id = Identificator++;
        }
        public Field(Enum E)
        {
            IntValue = 0;
            DblValue = 0;
            ChrValue = (Char)0;
            BolValue = false;
            _Id = Identificator++;

            if (EnmValue == null)
                EnmValue = new Dictionary<UInt64, Enum>();
            EnmValue.Add(Id, E);
        }
        public Field(Field Rewrite)
        {
            IntValue = Rewrite.IntValue;
            DblValue = Rewrite.DblValue;
            ChrValue = Rewrite.ChrValue;
            BolValue = Rewrite.BolValue;
            _Id = Rewrite.Id;
        }

        private UInt64 _Id;
        private UInt64 Id
        {
            get
            {
                if (_Id == 0)
                {
                    _Id = Identificator++;
                }
                return _Id;
            }
            set { _Id = value; }
        }        
        private static UInt64 Identificator = 0;

        private Int32 IntValue;
        private static CDictionary<Func<Int32, Int32>> IntGetters = new CDictionary<Func<int, int>>();
        private static CDictionary<Func<Int32, Int32>> IntSetters = new CDictionary<Func<int, int>>();
        public void OnGet(Func<Int32, Int32> Getter)
        { IntGetters.Add(this.Id, Getter); }
        public void OnSet(Func<Int32, Int32> Setter)
        { IntSetters.Add(this.Id, Setter); }
        public void Remove(Func<Int32, Int32> Xetter)
        {
            IntGetters.Remove(this.Id, Xetter);
            IntSetters.Remove(this.Id, Xetter);
        }
        public Int32 Int()
        {
            Int32 Value = this.IntValue;
            foreach (var Act in IntGetters[this.Id])
                Value = Act(Value);
            return Value;
        }
        public Int32 Int(Func<Int32, Int32> Exclude)
        {
            Int32 Value = this.IntValue;
            foreach (var Act in IntGetters[this.Id, Exclude])
                Value = Act(Value);
            return Value;
        }
        public void Int(Int32 Value)
        {
            foreach (var Act in IntSetters[this.Id])
                Value = Act(Value);
            IntValue = Value;
        }
        public void CleanInt(Int32 Value)
        { this.IntValue = Value; }
        public Int32 CleanInt()
        { return IntValue; }
        public static implicit operator Int32(Field Field)
        { return Field.Int(); }
        public static implicit operator Field(Int32 Value)
        {
            
            return new Field(Value);
        }
        public static Field operator +(Field Field, Int32 Value)
        {
            //take current real value
            Int32 AValue = Field.CleanInt();
            //set current value in field to 0
            Field.CleanInt(0);
            //set new value throught setters
            Field.Int(Value);
            //take new current value
            Int32 BValue = Field.CleanInt();
            //set old after setters value + new after setters value
            Field.CleanInt(AValue + BValue);
            return Field;
        }
        public static Field operator -(Field Field, Int32 Value)
        {
            Int32 AValue = Field.CleanInt();
            Field.CleanInt(0);
            Field.Int(Value);
            Int32 BValue = Field.CleanInt();
            Field.CleanInt(AValue - BValue);
            return Field;
        }
        public static Field operator *(Field Field, Int32 Value)
        {
            Int32 AValue = Field.CleanInt();
            Field.CleanInt(0);
            Field.Int(Value);
            Int32 BValue = Field.CleanInt();
            Field.CleanInt(AValue * BValue);
            return Field;
        }
        public static Field operator /(Field Field, Int32 Value)
        {
            Int32 AValue = Field.CleanInt();
            Field.CleanInt(0);
            Field.Int(Value);
            Int32 BValue = Field.CleanInt();
            Field.CleanInt(AValue / BValue);
            return Field;
        }

        private Double DblValue;
        private static CDictionary<Func<Double, Double>> DblGetters = new CDictionary<Func<double, double>>();
        private static CDictionary<Func<Double, Double>> DblSetters = new CDictionary<Func<double, double>>();
        public void OnGetDbl(Func<Double, Double> Getter)
        { DblGetters.Add(this.Id, Getter); }
        public void OnSetDbl(Func<Double, Double> Setter)
        { DblSetters.Add(this.Id, Setter); }
        public void RemoveDbl(Func<Double, Double> Xetter)
        {
            DblGetters.Remove(this.Id, Xetter);
            DblSetters.Remove(this.Id, Xetter);
        }
        public Double Double()
        {
            Double Value = this.DblValue;
            foreach (var Act in DblGetters[this.Id])
                Value = Act(Value);
            return Value;
        }
        public Double Double(Func<Double, Double> Exclude)
        {
            Double Value = this.DblValue;
            foreach (var Act in DblGetters[this.Id, Exclude])
                Value = Act(Value);
            return Value;
        }
        public void Double(Double Value)
        {
            foreach (var Act in DblSetters[this.Id])
                Value = Act(Value);
            DblValue = Value;
        }
        public void CleanDouble(Double Value)
        { DblValue = Value; }
        public Double CleanDouble()
        { return DblValue; }
        public static implicit operator Double(Field Field)
        { return Field.Double(); }
        public static implicit operator Field(Double Value)
        { return new Field(Value); }
        public static Field operator +(Field Field, Double Value)
        {
            Double AValue = Field.CleanDouble();
            Field.CleanDouble(0);
            Field.Double(Value);
            Double BValue = Field.CleanDouble();
            Field.CleanDouble(AValue + BValue);
            return Field;
        }
        public static Field operator -(Field Field, Double Value)
        {
            Double AValue = Field.CleanDouble();
            Field.CleanDouble(0);
            Field.Double(Value);
            Double BValue = Field.CleanDouble();
            Field.CleanDouble(AValue - BValue);
            return Field;
        }
        public static Field operator *(Field Field, Double Value)
        {
            Double AValue = Field.CleanDouble();
            Field.CleanDouble(0);
            Field.Double(Value);
            Double BValue = Field.CleanDouble();
            Field.CleanDouble(AValue * BValue);
            return Field;
        }
        public static Field operator /(Field Field, Double Value)
        {
            Double AValue = Field.CleanDouble();
            Field.CleanDouble(0);
            Field.Double(Value);
            Double BValue = Field.CleanDouble();
            Field.CleanDouble(AValue / BValue);
            return Field;
        }

        private Char ChrValue;
        private static CDictionary<Func<Char, Char>> ChrGetters = new CDictionary<Func<char, char>>();
        private static CDictionary<Func<Char, Char>> ChrSetters = new CDictionary<Func<char, char>>();
        public void OnGetChr(Func<Char, Char> Getter)
        { ChrGetters.Add(this.Id, Getter); }
        public void OnSetChr(Func<Char, Char> Setter)
        { ChrSetters.Add(this.Id, Setter); }
        public void RemoveChr(Func<Char, Char> Xetter)
        {
            ChrGetters.Remove(this.Id, Xetter);
            ChrSetters.Remove(this.Id, Xetter);
        }
        public Char Char()
        {
            Char Value = this.ChrValue;
            foreach (var Act in ChrGetters[this.Id])
                Value = Act(Value);
            return Value;
        }
        public Char Char(Func<Char, Char> Exclude)
        {
            Char Value = this.ChrValue;
            foreach (var Act in ChrGetters[this.Id, Exclude])
                Value = Act(Value);
            return Value;
        }
        public void Char(Char Value)
        {
            foreach (var Act in ChrSetters[this.Id])
                Value = Act(Value);
            ChrValue = Value;
        }
        public void CleanChar(Char Value)
        { ChrValue = Value; }
        public Char CleanChar()
        { return ChrValue; }
        public static implicit operator Char(Field Field)
        { return Field.Char(); }
        public static implicit operator Field(Char Value)
        { return new Field(Value); }
        public static Field operator +(Field Field, Char Value)
        {
            Field.Char(Value);
            return Field;
        }

        private Boolean BolValue;
        private static CDictionary<Func<Boolean, Boolean>> BolGetters = new CDictionary<Func<bool, bool>>();
        private static CDictionary<Func<Boolean, Boolean>> BolSetters = new CDictionary<Func<bool, bool>>();
        public void OnGet(Func<Boolean, Boolean> Getter)
        { BolGetters.Add(this.Id, Getter); }
        public void OnSet(Func<Boolean, Boolean> Setter)
        { BolSetters.Add(this.Id, Setter); }
        public void Remove(Func<Boolean, Boolean> Xetter)
        {
            BolGetters.Remove(this.Id, Xetter);
            BolSetters.Remove(this.Id, Xetter);
        }
        public Boolean Boolean()
        {
            Boolean Value = this.BolValue;
            foreach (var Act in BolGetters[this.Id])
                Value = Act(Value);
            return Value;
        }
        public Boolean Boolean(Func<Boolean, Boolean> Exclude)
        {
            Boolean Value = this.BolValue;
            foreach (var Act in BolGetters[this.Id, Exclude])
                Value = Act(Value);
            return Value;
        }
        public void Boolean(Boolean Value)
        {
            foreach (var Act in BolSetters[this.Id])
                Value = Act(Value);
            BolValue = Value;
        }
        public void CleanBoolean(Boolean Value)
        { BolValue = Value; }
        public Boolean CleanBoolean()
        { return BolValue; }
        public static implicit operator Boolean(Field Field)
        { return Field.Boolean(); }
        public static implicit operator Field(Boolean Value)
        { return new Field(Value); }
        public static Field operator +(Field Field, Boolean Value)
        {
            Field.Boolean(Value);
            return Field;
        }

        private static Dictionary<UInt64, String> StrValue;
        private static CDictionary<Func<String, String>> StrGetters = new CDictionary<Func<string, string>>();
        private static CDictionary<Func<String, String>> StrSetters = new CDictionary<Func<string, string>>();
        public void OnGet(Func<String, String> Getter)
        { StrGetters.Add(this.Id, Getter); }
        public void OnSet(Func<String, String> Setter)
        { StrSetters.Add(this.Id, Setter); }
        public void Remove(Func<String, String> Xetter)
        {
            StrGetters.Remove(this.Id, Xetter);
            StrSetters.Remove(this.Id, Xetter);
        }
        public String String()
        {
            if (StrValue.ContainsKey(this.Id))
            {
                String Value = StrValue[this.Id];
                foreach (var Act in StrGetters[this.Id])
                    Value = Act(Value);
                return Value;
            }
            else
                return "";
        }
        public String String(Func<String, String> Exclude)
        {
            String Value = StrValue[this.Id];
            foreach (var Act in StrGetters[this.Id, Exclude])
                Value = Act(Value);
            return Value;
        }
        public void String(String Value)
        {
            foreach (var Act in StrSetters[this.Id])
                Value = Act(Value);
            StrValue[this.Id] = Value;
        }
        public void CleanString(String Value)
        { StrValue[this.Id] = Value; }
        public String CleanString()
        { return StrValue[this.Id]; }
        public static implicit operator String(Field Field)
        { return Field.String(); }
        public static implicit operator Field(String Value)
        { return new Field(Value); }
        public static Field operator +(Field Field, String Value)
        {
            String AValue = Field.CleanString();
            Field.CleanString(string.Empty);
            Field.String(Value);
            String BValue = Field.CleanString();
            Field.CleanString(AValue + BValue);
            return Field;
        }
        public static Field operator -(Field Field, String Value)
        {
            String AValue = Field.CleanString();
            Field.CleanString(string.Empty);
            Field.String(Value);
            String BValue = Field.CleanString();
            Field.CleanString(AValue.Replace(BValue, ""));
            return Field;
        }
        public static Field operator /(Field Field, String Value)
        {
            String AValue = Field.CleanString();
            Field.CleanString(string.Empty);
            Field.String(Value);
            String BValue = Field.CleanString();
            Field.CleanString(string.Join("/", AValue.Split(BValue.ToCharArray())));
            return Field;
        }

        private static Dictionary<UInt64, Enum> EnmValue;
        private static CDictionary<Func<Enum, Enum>> EnmGetters = new CDictionary<Func<Enum, Enum>>();
        private static CDictionary<Func<Enum, Enum>> EnmSetters = new CDictionary<Func<Enum, Enum>>();
        public void OnGet(Func<Enum, Enum> Getter)
        { EnmGetters.Add(this.Id, Getter); }
        public void OnSet(Func<Enum, Enum> Setter)
        { EnmSetters.Add(this.Id, Setter); }
        public void Remove(Func<Enum, Enum> Xetter)
        {
            EnmGetters.Remove(this.Id, Xetter);
            EnmSetters.Remove(this.Id, Xetter);
        }
        public Enum Enum()
        {
            Enum Value = EnmValue[this.Id];
            foreach (var Act in EnmGetters[this.Id])
                Value = Act(Value);
            return Value;
        }
        public Enum Enum(Func<Enum, Enum> Exclude)
        {
            Enum Value = EnmValue[this.Id];
            foreach (var Act in EnmGetters[this.Id, Exclude])
                Value = Act(Value);
            return Value;
        }
        public void Enum(Enum Value)
        {
            foreach (var Act in EnmSetters[this.Id])
                Value = Act(Value);
            EnmValue[this.Id] = Value;
        }
        public void CleanEnum(Enum Value)
        { EnmValue[this.Id] = Value; }
        public Enum CleanEnum()
        { return EnmValue[this.Id]; }
        public static implicit operator Enum(Field Field)
        { return Field.Enum(); }
        public static implicit operator Field(Enum Value)
        { return new Field(Value); }
        public static Field operator +(Field Field, Enum Value)
        {
            Field.Enum(Value);
            return Field;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Enum EnmTempValue = default(Enum);
            try
            { EnmTempValue = EnmValue[this.Id]; }
            catch { }
            String StrTempValue = default(String);
            try
            { StrTempValue = StrValue[this.Id]; }
            catch { }
            sb.AppendLine("(" + StrTempValue + ")[" + this.IntValue + "]{" + this.DblValue + "}<" + this.BolValue + ">|" + this.ChrValue + "|$" + EnmTempValue + "$");
            return sb.ToString();
        }

        public IntPtr GetPtr()
        {
            return (IntPtr)0;
        }
    }

    public class CDictionary<TValue> : IEnumerable<TValue> where TValue : class
    {
        private List<Tuple<UInt64, TValue>> List = new List<Tuple<UInt64, TValue>>();

        public void Add(UInt64 Key, TValue Value)
        {
            List.Add(new Tuple<UInt64, TValue>(Key, Value));
        }
        public void Remove(UInt64 Key, TValue Value)
        {
            var Selected = (from a in List where a.Item1 == Key && a.Item2.Equals(Value) select a).ToList();
            if (Selected.Count != 0)
                foreach (var Item in Selected)
                    List.Remove(Item);
        }

        public IEnumerable<TValue> this[UInt64 Key]
        {
            get
            {
                IEnumerable<TValue> Something = (from a in List where a.Item1 == Key select a.Item2);
                return Something;
            }
        }
        public IEnumerable<TValue> this[UInt64 Key, TValue Exclude]
        {
            get
            {
                IEnumerable<TValue> Something = (from a in List where a.Item1 == Key && !a.Item2.Equals(Exclude) select a.Item2);
                return Something;
            }
        }
        public IEnumerator<TValue> GetEnumerator()
        {
            foreach (var Value in List)
                yield return Value.Item2;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}