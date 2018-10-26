using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcTests
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
                CalcGui.Calc Calc1 = new CalcGui.Calc();

                if (Calc1.CurrentValue != 0) throw new Exception("current_value_incorrect");
                if (Calc1.get_DisplayedValue() != "0") throw new Exception("displayed_value_incorrect");
            }
        }

        public class unit_conversion_test : Test
        {
            public override void Perform()
            {
                CalcGui.Calc Calc1 = new CalcGui.Calc();

                Calc1.set_value(10);
                Calc1.set_format(Displayformats.Bin);
                if (Calc1.get_DisplayedValue() != "1010") throw new Exception("displayed_value_incorrect(wrong conversion bin)");
                Calc1.set_format(Displayformats.Hex);
                if (Calc1.get_DisplayedValue() != "A") throw new Exception("displayed_value_incorrect(wrong conversion hex)");
                Calc1.set_format(Displayformats.Oct);
                if (Calc1.get_DisplayedValue() != "12") throw new Exception("displayed_value_incorrect(wrong conversion oct)");
                Calc1.set_format(Displayformats.Dec);
                if (Calc1.get_DisplayedValue() != "10") throw new Exception("displayed_value_incorrect(wrong conversion Dec)");


            }
        }

    }
}
