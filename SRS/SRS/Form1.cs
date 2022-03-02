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

        private void Form1_Load(object sender, EventArgs e)
        {

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
                if ((e.KeyChar < '1') || (e.KeyChar > '4'))//这是允许输入1-4数字
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDIS_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //使用户的输入失效
        }

        private int getValue(TextBox t)
        {
            if (t.Text == "")            
            {
                return 0;
            }
            try
            {
                int value = Int32.Parse(t.Text);
                return value;
            }
            catch (FormatException e)
            {
                return 0;
            }           
        }
        private void calculate()
        {
            textBox66.Text = (getValue(textBox2) - getValue(textBox7) + getValue(textBox25) - getValue(textBox32) - getValue(textBox45) - getValue(textBox52)
                + getValue(textBox54) + getValue(textBox56) + 12).ToString();
            textBox67.Text = (getValue(textBox5) + getValue(textBox10) - getValue(textBox15) - getValue(textBox17) + getValue(textBox30) - getValue(textBox40)
                + getValue(textBox42) + getValue(textBox44) - getValue(textBox48) + getValue(textBox58) + getValue(textBox59) + getValue(textBox62) + 8).ToString();
            textBox68.Text = (0 - getValue(textBox12) + getValue(textBox13) + getValue(textBox16) + getValue(textBox18) + getValue(textBox19)
                - getValue(textBox21) - getValue(textBox22) - getValue(textBox26) + getValue(textBox33) + getValue(textBox35) + getValue(textBox36)
                + getValue(textBox37) - getValue(textBox38) + getValue(textBox41) + getValue(textBox46) + getValue(textBox47) + getValue(textBox51)
                + getValue(textBox53) - getValue(textBox55) + getValue(textBox57) + getValue(textBox60) + getValue(textBox61) + 8).ToString();
            textBox69.Text = (getValue(textBox1) - getValue(textBox3) + getValue(textBox6) + getValue(textBox9) - getValue(textBox11) + getValue(textBox23)
                + getValue(textBox27) + getValue(textBox34) - getValue(textBox43) + getValue(textBox64) + getValue(textBox65) + 4).ToString();
            textBox70.Text = (getValue(textBox39) + getValue(textBox49) + getValue(textBox50) + getValue(textBox63) + getValue(textBox4) + getValue(textBox8) 
                + getValue(textBox14) + getValue(textBox20) + getValue(textBox24) + getValue(textBox28) + getValue(textBox29) + getValue(textBox31) - 12).ToString();
            textBox71.Text = (getValue(textBox66) + getValue(textBox67) + getValue(textBox68) + getValue(textBox69) + getValue(textBox70)).ToString();
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
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox28.Clear();
            textBox29.Clear();
            textBox30.Clear();
            textBox31.Clear();
            textBox32.Clear();
            textBox33.Clear();
            textBox34.Clear();
            textBox35.Clear();
            textBox36.Clear();
            textBox37.Clear();
            textBox38.Clear();
            textBox39.Clear();
            textBox40.Clear();
            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();
            textBox45.Clear();
            textBox46.Clear();
            textBox47.Clear();
            textBox48.Clear();
            textBox49.Clear();
            textBox50.Clear();
            textBox51.Clear();
            textBox52.Clear();
            textBox53.Clear();
            textBox54.Clear();
            textBox55.Clear();
            textBox56.Clear();
            textBox57.Clear();
            textBox58.Clear();
            textBox59.Clear();
            textBox60.Clear();
            textBox61.Clear();
            textBox62.Clear();
            textBox63.Clear();
            textBox64.Clear();
            textBox65.Clear();
            textBox1.Focus();
        }
    }
}
