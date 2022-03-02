using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Weiss
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
                Control c = this.GetNextControl((Control)sender, true);
                Console.WriteLine(c);
                c.Focus();
            }
            calculate();            
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '3'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                this.GetNextControl((Control)sender, true).Focus();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                Control c = this.GetNextControl((Control)sender, false);
                if (c != null)
                {
                    c.Focus();
                }
            }
        }

        private void txtDIS_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //使用户的输入失效
        }

        private int getValue(TextBox t, bool reverse = false)
        {
            if (t.Text == "")            
            {
                return -1;
            }
            try
            {
                int value = Int32.Parse(t.Text);
                if (reverse)
                {
                    value = 3 - value;
                }
                return value;
            }
            catch (FormatException e)
            {
                return 0;
            }           
        }

        private int calculateTotal(TextBox[] tbs)
        {
            int total = 0;
            foreach (TextBox tb in tbs)
            {
                int value;
                if (tb == textBox22 || tb == textBox37)
                {
                    value = getValue(tb, true);
                }
                else
                {
                    value = getValue(tb);
                }
                if (value != -1)
                {
                    total += value;
                }
            }
            return total;
        }

        private int calculateEffiectiveCount(TextBox[] tbs)
        {
            int count = 0;
            foreach (TextBox tb in tbs)
            {
                int value;
                if (tb == textBox22 || tb == textBox37)
                {
                    value = getValue(tb, true);
                }
                else
                {
                    value = getValue(tb);
                }
                if (value != -1)
                {
                    count += 1;
                }                
            }
            return count;
        }

        private bool calculateWarning(TextBox[] tbs, int total, int count)
        {
            if (count == 0)
            {
                return false;
            }
            int count2 = 0;
            int count3 = 0;
            foreach (TextBox tb in tbs)
            {
                int value;
                if (tb == textBox22 || tb == textBox37)
                {
                    value = getValue(tb, true);
                }
                else
                {
                    value = getValue(tb);
                }
                if (value == 2)
                {
                    count2 += 1;
                }
                else if (value == 3)
                {
                    count3 += 1;
                }
            }
            float avgScore = total / count;
            if (count3 >= 1 || count2 >=2 || avgScore > 1.5)
            {
                return true;
            }
            return false;
        }


        private void calculate()
        {
            TextBox[] tbsA = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            TextBox[] tbsB = new TextBox[] { textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20 };
            TextBox[] tbsC = new TextBox[] { textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30 };
            TextBox[] tbsD = new TextBox[] { textBox31, textBox32, textBox33 };
            TextBox[] tbsE = new TextBox[] { textBox34, textBox35, textBox36, textBox37, textBox38, textBox39, textBox40 };
            TextBox[] tbsF = new TextBox[] { textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, textBox48, textBox49, textBox50 };

            int totalA = calculateTotal(tbsA);
            int totalB = calculateTotal(tbsB);
            int totalC = calculateTotal(tbsC);
            int totalD = calculateTotal(tbsD);
            int totalE = calculateTotal(tbsE);
            int totalF = calculateTotal(tbsF);

            int countA = calculateEffiectiveCount(tbsA);
            int countB = calculateEffiectiveCount(tbsB);
            int countC = calculateEffiectiveCount(tbsC);
            int countD = calculateEffiectiveCount(tbsD);
            int countE = calculateEffiectiveCount(tbsE);
            int countF = calculateEffiectiveCount(tbsF);

            textBox65.Text = totalA.ToString();
            textBox66.Text = totalB.ToString();
            textBox67.Text = totalC.ToString();
            textBox68.Text = totalD.ToString();
            textBox69.Text = totalE.ToString();
            textBox70.Text = totalF.ToString();
            textBox71.Text = (totalA + totalB + totalC + totalD + totalE + totalF).ToString();
            if ((countA + countB + countC + countD + countE + countF) == 0)
            {
                textBox72.Text = "0";
            } else
            {
                textBox72.Text = (Math.Round((totalA + totalB + totalC + totalD + totalE + totalF) / (float)(countA + countB + countC + countD + countE + countF), 2)).ToString();
            }            

            if (calculateWarning(tbsA, totalA, countA))
            {
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
            }
            if (calculateWarning(tbsB, totalB, countB))
            {
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox2.Visible = false;
            }
            if (calculateWarning(tbsC, totalC, countC))
            {
                pictureBox3.Visible = true;
            }
            else
            {
                pictureBox3.Visible = false;
            }
            if (calculateWarning(tbsD, totalD, countD))
            {
                pictureBox4.Visible = true;
            }
            else
            {
                pictureBox4.Visible = false;
            }
            if (calculateWarning(tbsE, totalE, countE))
            {
                pictureBox5.Visible = true;
            }
            else
            {
                pictureBox5.Visible = false;
            }
            if (calculateWarning(tbsF, totalF, countF))
            {
                pictureBox6.Visible = true;
            }
            else
            {
                pictureBox6.Visible = false;
            }
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
            textBox1.Focus();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;            
        }
    }
}
