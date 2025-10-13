using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GymMSWF
{
    public partial class Dashboardd : UserControl
    {
        public Dashboardd()
        {
            InitializeComponent();
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);

            ChartArea area = new ChartArea();
            chart.ChartAreas.Add(area);

            Series series = new Series();
            series.Points.AddXY("Jan", 100);
            series.Points.AddXY("Feb", 150);
            series.Points.AddXY("Mar", 120);
            chart.Series.Add(series);
        }
    }
}
