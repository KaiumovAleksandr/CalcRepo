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
    }
}
