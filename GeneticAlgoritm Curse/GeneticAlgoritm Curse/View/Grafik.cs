using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneticAlgoritm_Curse.Model;

namespace GeneticAlgoritm_Curse
{
    public partial class Grafik : Form
    {
        private List<double> KoefMassiv = null;
        private List<double> KoefMassiv_new = null;
        public Grafik(List<double> KoefMassiv, List<double> KoefMassiv_new)
        {
            InitializeComponent();
            this.KoefMassiv = KoefMassiv;
            this.KoefMassiv_new = KoefMassiv_new;
            this.chart1.Series[0].BorderWidth = 3;
            this.chart1.Series[0].LegendText = "Пример лучшего";
            this.chart1.Series.Add("Первое поколение");
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            this.chart1.Series[1].BorderWidth = 3;
            this.chart1.Series.Add("Второе поколение");
            this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            this.chart1.Series[2].BorderWidth = 3;
        }
        public void Graf()
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            this.chart1.Series[2].Points.Clear();
            int best = 1;
            double x, y, a = 0, b = 10;
            x = a;
            for (double i = 0; i < KoefMassiv.Count; i++)
            {
                y = best;
                this.chart1.Series[0].Points.AddXY(x, y);
            }
            for (int i = 0; i < KoefMassiv.Count; i++)
            {
                y = KoefMassiv[i];
                this.chart1.Series[1].Points.AddXY(x, y);
            }
            for (int i = 0; i < KoefMassiv_new.Count; i++)
            {
                y = KoefMassiv_new[i];
                this.chart1.Series[2].Points.AddXY(x, y);
            }
        }
    }
}
