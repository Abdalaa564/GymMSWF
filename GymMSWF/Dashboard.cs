using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void LoadPage(UserControl page)
        {
            panelDashboard.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelDashboard.Controls.Add(page);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new Dashboardd());
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            LoadPage(new About());
        }


    }
}
