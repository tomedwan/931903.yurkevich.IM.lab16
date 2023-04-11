using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.05;
        int i = -1;
        double rate;
        double rubles = 100;
        int dollars = 0;
        private void btStart_Click(object sender, EventArgs e)
        {
            if (i < 0)
            {
                Random random = new Random();
                rate = (double)edRate.Value;
                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(0, rate);

                i++;

                textBox4.Text = rate.ToString("F2");
                rate = rate * (1 + k * (random.NextDouble() - 0.5));
                chart1.Series[0].Points.AddXY(i, rate);

                textBox1.Text = rubles.ToString("F2");
                textBox2.Text = dollars.ToString();
                textBox3.Text = "          ";
                edRate.Value = (decimal)rate;

                btStart.Text = "Закончить";
                label1.Text = "Примерный завтрашний курс";
                label4.Text = "Сегодняшний курс";
            }
            else
            {
                Close();
            }
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            if (rubles >= rate) 
            {
                dollars++;
                rubles -= rate;
                textBox1.Text = rubles.ToString("F2");
                textBox2.Text = dollars.ToString();
                textBox3.Text = "Поздравляем с покупкой в нашем лохотроне";
            }
            else
            {
                textBox3.Text = "Бомж!"; 
            }
        }

        private void Sale_Click(object sender, EventArgs e)
        {
            if (dollars >= 1)
            {
                dollars--;
                rubles += rate;
                textBox1.Text = rubles.ToString("F2");
                textBox2.Text = dollars.ToString();
                textBox3.Text = "Надеемся это даст вам надежду";
            }
            else
            {
                textBox3.Text = "В кормашке то пусто!"; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                Random random = new Random();
                rate = (double)edRate.Value;
                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(0, rate);

                i++;
                textBox4.Text = rate.ToString("F2");
                rate = rate * (1 + k * (random.NextDouble() - 0.5));

                chart1.Series[0].Points.AddXY(i, rate);

                textBox1.Text = rubles.ToString("F2");
                textBox2.Text = dollars.ToString();
                textBox3.Text = "          ";
                edRate.Value = (decimal)rate;
            }

        }
    }
}
