using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcPM
{
    public partial class Form1 : Form
    {
        private double memory = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            textBox_Expression.Text += ((Button)sender).Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox_Expression.Text += $" {((Button)sender).Text} ";
        }

        private void button_Backspace_Click(object sender, EventArgs e)
        {
            if(textBox_Expression.Text.Length > 0) textBox_Expression.Text = textBox_Expression.Text.Substring(0, textBox_Expression.Text.Length - 1);
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            textBox_Expression.Clear();
        }

        private void button_MS_Click(object sender, EventArgs e)
        {
            bool resParse = double.TryParse(textBox_Result.Text, out memory);
            if (!resParse) MessageBox.Show("Parse to number is impossible");
            else label_Memory.Text = $"M\r\n{memory}";
        }

        private void button_Mplus_Click(object sender, EventArgs e)
        {
            double temp;
            bool resParse = double.TryParse(textBox_Result.Text, out temp);
            if (!resParse) MessageBox.Show("Parse to number is impossible");
            else
            {
                memory += temp;
                label_Memory.Text = $"M\r\n{memory}";
            }
        }

        private void button_Mminus_Click(object sender, EventArgs e)
        {
            double temp;
            bool resParse = double.TryParse(textBox_Result.Text, out temp);
            if (!resParse) MessageBox.Show("Parse to number is impossible");
            else
            {
                memory -= temp;
                label_Memory.Text = $"M\r\n{memory}";
            }
        }

        private void button_MC_Click(object sender, EventArgs e)
        {
            memory = 0;
            label_Memory.Text = $"M\r\n{memory}";
        }

        private void button_MR_Click(object sender, EventArgs e)
        {
            textBox_Expression.Text += memory.ToString();
        }

        private void button_PlusMinus_Click(object sender, EventArgs e)
        {
            if(textBox_Expression.Text.Length > 0)
            {
                StringBuilder str = new StringBuilder();
                double temp;
                bool resParse;
                for (int i = textBox_Expression.Text.Length - 1; i >= 0; i--)
                {
                    if (!Char.IsDigit(textBox_Expression.Text[i]) && textBox_Expression.Text[i] != '.' && textBox_Expression.Text[i] != '-')
                    {
                        resParse = double.TryParse(str.ToString(), out temp);
                        if(resParse)
                        {
                            StringBuilder tmp = new StringBuilder(textBox_Expression.Text);
                            if (temp > 0) tmp.Insert(i + 1, '-');
                            else tmp.Remove(i + 1, 1);
                            textBox_Expression.Text = tmp.ToString();
                            break;
                        }
                    }
                    else
                    {
                        str.Insert(0, textBox_Expression.Text[i]);
                        if (i == 0)
                        {
                            if(textBox_Expression.Text[0] != '-') str.Insert(0, '-');
                            else str.Remove(0,1);
                            textBox_Expression.Text = str.ToString();
                        }
                    }
                }
            }
            
        }

    }
}
