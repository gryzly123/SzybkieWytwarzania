using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;
            Test CurrentTest = GetTest(Btn);
            try
            {
                Btn.BackColor = Color.Green;
                CurrentTest.Perform();
            }
            catch (Exception E)
            {
                Btn.BackColor = Color.Red;
                MessageBox.Show(E.ToString());
            }
        }

        private Test GetTest(Button btn)
        {
            if (btn == BtnTest1) return new InitValueTest();
            if (btn == BtnTest2) return new keyboard_input_test_positive();
            return null;
        }

        public abstract class Test
        {
            public abstract void Perform();
        }

        public class InitValueTest : Test
        {
            public override void Perform()
            {
                Calc Calc1 = new Calc();

                if (Calc1.CurrentValue != 0) throw new Exception("current_value_incorrect");
                if (Calc1.get_DisplayedValue() != "0") throw new Exception("displayed_value_incorrect");
                if (Calc1.get_CurrentFormat() != DisplayFormats.Dec) throw new Exception("Incorrect display format");
                if (Calc1.get_CurrentSize() != VariableSize.QWord) throw new Exception("Incorrect variable size");
                foreach (bool item in Calc1.GetBitflags())
                {
                    if (item == true) throw new Exception("Initial bit flags are not 0");
                }
            }
        }

        public class keyboard_input_test_positive : Test
        {
            public override void Perform()
            {
                Calc Calc1 = new Calc();
                Calc1.set_format(DisplayFormats.Bin);

                Calc1.OnKeyInput(ConsoleKey.D1);
                Calc1.OnKeyInput(ConsoleKey.D0);
                Calc1.OnKeyInput(ConsoleKey.D1);
                Calc1.OnKeyInput(ConsoleKey.D0);
                Calc1.OnKeyInput(ConsoleKey.D1);
                Calc1.OnKeyInput(ConsoleKey.D1);
                if (Calc1.get_DisplayedValue() != "101011")
                    throw new Exception("invalid_input_in_binary");

            }
        }

        public class unit_conversion_test_positive : Test
        {
            public override void Perform()
            {
                Calc Calc1 = new Calc();

                Calc1.set_value(10);
                Calc1.set_format(DisplayFormats.Bin);
                if (Calc1.get_DisplayedValue() != "1010") throw new Exception("displayed_value_incorrect(wrong conversion bin)");
                Calc1.set_format(DisplayFormats.Hex);
                if (Calc1.get_DisplayedValue() != "A") throw new Exception("displayed_value_incorrect(wrong conversion hex)");
                Calc1.set_format(DisplayFormats.Oct);
                if (Calc1.get_DisplayedValue() != "12") throw new Exception("displayed_value_incorrect(wrong conversion oct)");
                Calc1.set_format(DisplayFormats.Dec);
                if (Calc1.get_DisplayedValue() != "10") throw new Exception("displayed_value_incorrect(wrong conversion Dec)");


            }
        }

    }
}
