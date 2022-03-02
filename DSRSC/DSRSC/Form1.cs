using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SRS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != "")
            {   
                this.GetNextControl((Control)sender, true).Focus();
            }
            calculate();            
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '2'))//这是允许输入0-2数字
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDIS_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //使用户的输入失效
        }

        private int getValue(TextBox t, bool reverse=false)
        {
            if (t.Text == "")            
            {
                return 0;
            }
            try
            {
                int value = Int32.Parse(t.Text);
                if (reverse)
                {
                    value = 2 - value;
                }
                return value;
            }
            catch (FormatException e)
            {
                return 0;
            }           
        }
        private void calculate()
        {
            int notReverseValue = getValue(textBox3) + getValue(textBox5) + getValue(textBox6) + getValue(textBox10)
                + getValue(textBox14) + getValue(textBox15) + getValue(textBox17) + getValue(textBox18);
            int reverseValue = getValue(textBox1, true) + getValue(textBox2, true) + getValue(textBox4, true) + getValue(textBox7, true)
                + getValue(textBox8, true) + getValue(textBox9, true) + getValue(textBox11, true) + getValue(textBox12, true) + getValue(textBox13, true)
                + getValue(textBox16, true);
            textBox71.Text = (notReverseValue + reverseValue).ToString();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox1.Focus();
        }
    }
}
