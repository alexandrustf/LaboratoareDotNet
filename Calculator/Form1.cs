using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            new Button();
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "4";
            }
            else
            {
                textBox2.Text = textBox2.Text + "4";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "5";
            }
            else
            {
                textBox2.Text = textBox2.Text + "5";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "6";
            }
            else
            {
                textBox2.Text = textBox2.Text + "6";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "1";
            }
            else
            {
                textBox2.Text = textBox2.Text + "1";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
            }
            else
            {
                textBox2.Text = textBox2.Text + "+";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
            }
            else
            {
                textBox2.Text = textBox2.Text + "*";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "2";
            }
            else
            {
                textBox2.Text = textBox2.Text + "2";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "3";
            }
            else
            {
                textBox2.Text = textBox2.Text + "3";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "7";
            }
            else
            {
                textBox2.Text = textBox2.Text + "7";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "8";
            }
            else
            {
                textBox2.Text = textBox2.Text + "8";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "9";
            }
            else
            {
                textBox2.Text = textBox2.Text + "9";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
                textBox2.Text = "0";
            }
            else
            {
                textBox2.Text = textBox2.Text + "0";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
            }
            else
            {
                var result = CalculateResult();
                textBox2.Text = result.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
            }
            else
            {
                textBox2.Text = textBox2.Text + "-";
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
            }
            else
            {
                textBox2.Text = textBox2.Text + "/";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" && textBox2.Text != null)
            {
            }
            else
            {
                textBox2.Text = textBox2.Text + ".";
            }
        }

        private double CalculateResult()
        {
            string toBeCalculated = textBox2.Text;
            double number1;
            char[] delimiterChars = { '+', '-', '*', '/' };
            var filtered = toBeCalculated.Where(x => "+-*/".Contains(x)).ToArray();
            var spllited = toBeCalculated.Split(delimiterChars);
            var numbers = spllited.Select(n => Convert.ToDouble(n)).ToArray();
            double result = 0;

            var len = numbers.Count();
            result = numbers[0];
            for (int i = 1; i < len; i++)
            {
                result = ResolveOperation(filtered[i-1], result, numbers[i]);
            }
            return result;
        }

        private double ResolveOperation(char c, double num1, double num2)
        {
            if (c.Equals('+'))
            {
                return num1 + num2;
            }
            if (c.Equals('-'))
            {
                return num1 - num2;
            }
            if (c.Equals('*'))
            {
                return num1 * num2;
            }
            if (c.Equals('/'))
            {
                return num1 / num2;
            }
            return 0;
        }

        private void button15_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.KeyChar
        }
    }
}
