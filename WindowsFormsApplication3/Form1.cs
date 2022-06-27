using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        float a, b, c, k, step, start, end;

        public Form1()
        {
            InitializeComponent();

            a = b = c = k = step = 1;
            start = -100;
            end = 100;
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = textBox5.Text = "1";
            textBox6.Text = start.ToString();
            textBox7.Text = end.ToString();
            Update();
        }

        private void Update()
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int W = pictureBox1.Width, H = pictureBox1.Height;
            int halfW = W / 2, halfH = H / 2;
            float x0, y0, y;

            e.Graphics.DrawLine(Pens.Black, halfW, 0, halfW, H);
            e.Graphics.DrawLine(Pens.Black, 0, halfH, W, halfH);

            x0 = start;
            y0 = (float)Convert.ToDouble(a * Math.Pow(x0, 2) + b * x0 + c);

            for (float x = start + step; x < end; x += step)
            {
                y = (float)Convert.ToDouble(a * Math.Pow(x, 2) + b * x + c);

                e.Graphics.DrawLine(Pens.Red, x0 + halfW, -y0 + halfH, x + halfW, -y + halfH);

                x0 = x;
                y0 = y;
            }

            string f = "";
            if (a != 0)
            {
                if (a != 1 && a != -1)
                    f += a.ToString() + "x^2";
                else if (a == 1)
                    f += "x^2";
                else
                    f += "-x^2";
            }
            if (b != 0)
            {
                if (b > 0)
                {
                    if (a != 0)
                        f += " + ";
                    if (b != 1)
                        f += b.ToString() + "x";
                    else
                        f += "x";
                }
                else if (b < 0)
                {
                    f += " - ";
                    if (b != -1)
                        f += (-b).ToString();
                    else
                        f += "x";
                }
            }
            if (c != 0)
            {
                if (c > 0)
                {
                    if (a != 0 || b != 0)
                        f += " + ";
                    f += c.ToString();
                }
                else if (c < 0)
                {
                    f += " - " + (-c).ToString();
                }
            }
            f += " = 0";
            e.Graphics.DrawString(f, DefaultFont, Brushes.Red, new PointF(0, 0));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = (float)Convert.ToDouble(TextBox1.Text);
                b = (float)Convert.ToDouble(TextBox2.Text);
                c = (float)Convert.ToDouble(TextBox3.Text);
                k = (float)Convert.ToDouble(TextBox4.Text);
                step = (float)Convert.ToDouble(textBox5.Text);
                start = (float)Convert.ToDouble(textBox6.Text);
                end = (float)Convert.ToDouble(textBox7.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода.");

                return;
            }

            Update();
        }
    }
}
