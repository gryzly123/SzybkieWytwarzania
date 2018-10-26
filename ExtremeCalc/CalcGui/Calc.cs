using System;

namespace CalcGui
{
    public enum Displayformats
    {
        Bin = 2,
        Oct = 8,
        Dec = 10,
        Hex = 16
    }

    public class Calc
    {
        public Calc()
        {
            CurrentValue = 0;
        }

        public Displayformats = 

        public Int64 CurrentValue { get; set; }
        public string get_DisplayedValue()
        {
            string display_val = CurrentValue.ToString();
            return display_val;
        }

        public void set_value(int v)
        {
            throw new NotImplementedException();
        }

        public void set_format(object bin)
        {
            throw new NotImplementedException();
        }
    }
}