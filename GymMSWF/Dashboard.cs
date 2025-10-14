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

        public void LoadForm(Form form)
        {
            mainPanel.Controls.Clear();      // نحذف أي شاشة سابقة
            form.TopLevel = false;          // عشان يشتغل داخل فورم تاني
            form.FormBorderStyle = FormBorderStyle.None; // نخفي البوردر
            form.Dock = DockStyle.Fill;      // ياخد كل المساحة
            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadForm(new Dashboardd());
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            LoadForm(new About());
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            //var form = new Packages();
            //form.Show(); // تفتح نافذة جديدة
            LoadForm(new Packages());
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            LoadForm(new ClientPage());
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            LoadForm(new InstructorForm());
        }
    }
}
