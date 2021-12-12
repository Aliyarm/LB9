using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "-0,75";
            textBox2.Text = "-1,5";
            textBox3.Text = "-0,05";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // начальные значения
            double Xmax = double.Parse(textBox1.Text);
            double Xmin = double.Parse(textBox2.Text);
            double Step = double.Parse(textBox3.Text);

            double a = 1.5;
            double b = 1.2;

            int count = (int)Math.Ceiling((Xmax - Xmin) / Math.Abs(Step)) + 1; // количество точек графика
            double[] x = new double[Math.Abs(count)]; // массив координат Х
            double[] y1 = new double[Math.Abs(count)]; // массив координат У

            for (int i = 0; i < Math.Abs(count); i++) // выполнение цикла пока не зададим все точки графика
            {
                x[i] = Xmin + Math.Abs(Step) * i; // вычисление Х координаты
                y1[i] = 1.2 * Math.Pow(a - b, 3) * Math.Exp(Math.Pow(x[i], 2)) + x[i]; // вычисление У координаты по формуле задания из Л.Р №4
            }
            // отрисовка графика на элементе управления Chart
            chart1.ChartAreas[0].AxisX.Minimum = Xmin;
            chart1.ChartAreas[0].AxisX.Maximum = Xmax;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Math.Abs(Step);
            chart1.Series[0].Points.DataBindXY(x, y1);
        }
    }
}
