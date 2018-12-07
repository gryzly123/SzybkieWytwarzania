using System;
using System.Collections.Generic;

namespace CalcGui
{
    public enum DisplayFormats
    {
        Bin = 2,
        Oct = 8,
        Dec = 10,
        Hex = 16
    }

    public enum VariableSize
    {
        Byte = 8,
        Word = 16,
        DWord = 32,
        QWord = 64
    }

    public class Calc
    {
        public Calc()
        {
            CurrentValue = 0;
        }

        private DisplayFormats CurrentFormat = DisplayFormats.Dec;
        private VariableSize CurrentSize = VariableSize.QWord;
        private bool[] Bitflags = new bool[64];

        public Int64 CurrentValue { get; set; }
        public string get_DisplayedValue()
        {
            string display_val = Convert.ToString(CurrentValue, (int)CurrentFormat);
            return display_val;
        }

        public void set_value(int new_value)
        {
            throw new NotImplementedException();
        }

        public void set_format(DisplayFormats new_format)
        {
            CurrentFormat = new_format;

            ValidKeys.Clear();
            switch(CurrentFormat)
            {
                case DisplayFormats.Bin:
                    ValidKeys.Add(ConsoleKey.D0);
                    ValidKeys.Add(ConsoleKey.D1);
                    ValidKeys.Add(ConsoleKey.NumPad0);
                    ValidKeys.Add(ConsoleKey.NumPad1);
                    break;
                case DisplayFormats.Dec:
                    ValidKeys.Add(ConsoleKey.D0);
                    ValidKeys.Add(ConsoleKey.D1);
                    ValidKeys.Add(ConsoleKey.NumPad0);
                    ValidKeys.Add(ConsoleKey.NumPad1);
                    ValidKeys.Add(ConsoleKey.D2);
                    ValidKeys.Add(ConsoleKey.D3);
                    ValidKeys.Add(ConsoleKey.NumPad2);
                    ValidKeys.Add(ConsoleKey.NumPad3);
                    ValidKeys.Add(ConsoleKey.D4);
                    ValidKeys.Add(ConsoleKey.D5);
                    ValidKeys.Add(ConsoleKey.NumPad4);
                    ValidKeys.Add(ConsoleKey.NumPad5);
                    ValidKeys.Add(ConsoleKey.D6);
                    ValidKeys.Add(ConsoleKey.D7);
                    ValidKeys.Add(ConsoleKey.NumPad6);
                    ValidKeys.Add(ConsoleKey.NumPad7);
                    ValidKeys.Add(ConsoleKey.D8);
                    ValidKeys.Add(ConsoleKey.D9);
                    ValidKeys.Add(ConsoleKey.NumPad8);
                    ValidKeys.Add(ConsoleKey.NumPad9);
                    break;
                case DisplayFormats.Oct:
                    ValidKeys.Add(ConsoleKey.D0);
                    ValidKeys.Add(ConsoleKey.D1);
                    ValidKeys.Add(ConsoleKey.NumPad0);
                    ValidKeys.Add(ConsoleKey.NumPad1);
                    ValidKeys.Add(ConsoleKey.D2);
                    ValidKeys.Add(ConsoleKey.D3);
                    ValidKeys.Add(ConsoleKey.NumPad2);
                    ValidKeys.Add(ConsoleKey.NumPad3);
                    ValidKeys.Add(ConsoleKey.D4);
                    ValidKeys.Add(ConsoleKey.D5);
                    ValidKeys.Add(ConsoleKey.NumPad4);
                    ValidKeys.Add(ConsoleKey.NumPad5);
                    ValidKeys.Add(ConsoleKey.D6);
                    ValidKeys.Add(ConsoleKey.D7);
                    ValidKeys.Add(ConsoleKey.NumPad6);
                    ValidKeys.Add(ConsoleKey.NumPad7);
                    break;
                case DisplayFormats.Hex:
                    ValidKeys.Add(ConsoleKey.D0);
                    ValidKeys.Add(ConsoleKey.D1);
                    ValidKeys.Add(ConsoleKey.NumPad0);
                    ValidKeys.Add(ConsoleKey.NumPad1);
                    ValidKeys.Add(ConsoleKey.D2);
                    ValidKeys.Add(ConsoleKey.D3);
                    ValidKeys.Add(ConsoleKey.NumPad2);
                    ValidKeys.Add(ConsoleKey.NumPad3);
                    ValidKeys.Add(ConsoleKey.D4);
                    ValidKeys.Add(ConsoleKey.D5);
                    ValidKeys.Add(ConsoleKey.NumPad4);
                    ValidKeys.Add(ConsoleKey.NumPad5);
                    ValidKeys.Add(ConsoleKey.D6);
                    ValidKeys.Add(ConsoleKey.D7);
                    ValidKeys.Add(ConsoleKey.NumPad6);
                    ValidKeys.Add(ConsoleKey.NumPad7);
                    ValidKeys.Add(ConsoleKey.D8);
                    ValidKeys.Add(ConsoleKey.D9);
                    ValidKeys.Add(ConsoleKey.NumPad8);
                    ValidKeys.Add(ConsoleKey.NumPad9);
                    ValidKeys.Add(ConsoleKey.A);
                    ValidKeys.Add(ConsoleKey.B);
                    ValidKeys.Add(ConsoleKey.C);
                    ValidKeys.Add(ConsoleKey.D);
                    ValidKeys.Add(ConsoleKey.E);
                    ValidKeys.Add(ConsoleKey.F);
                    break;



            }
        }

        public DisplayFormats get_CurrentFormat()
        {
            return CurrentFormat;
        }

        public VariableSize get_CurrentSize()
        {
            return CurrentSize;
        }

        public IEnumerable<bool> GetBitflags()
        {
            return Bitflags;
        }

        private List<ConsoleKey> ValidKeys = new List<ConsoleKey>();

        public bool OnKeyInput(ConsoleKey K)
        {
            if (!ValidKeys.Contains(K)) return false;
            CurrentValue *= (long)CurrentFormat;
            CurrentValue += GetIntFromKey(K);
            return true;
        }

        private long GetIntFromKey(ConsoleKey k)
        {
            switch(k)
            {
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    return 0;

                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return 1;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return 2;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return 3;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return 4;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    return 5;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    return 6;

                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    return 7;

                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    return 8;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    return 9;
            }
            throw new Exception("what the fuck");
        }
    }
}
