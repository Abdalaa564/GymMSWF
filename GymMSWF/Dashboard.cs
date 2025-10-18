using GymData.Models;
using GymServices;
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
        private readonly bool _isAdmin;
        private readonly AttendanceService _attendanceService;

        public Dashboard(bool isAdmin)
        {
            InitializeComponent();
            _isAdmin = isAdmin;
            SetupUI();

            var context = DbContext.CreateDbContext();
            _attendanceService = new AttendanceService(context);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //mainPanel.AutoScroll = true;
            //mainPanel.Dock = DockStyle.Fill;
            //mainPanel.Padding = new Padding(5);

        }

        private void SetupUI()
        {
            if (!_isAdmin)
            {
                btnInstructors.Visible = false;
                btnDashboard.Visible = false;
                btnMemberShips.Visible = false;
                //btnPackages.Visible = false;     
            }
        }

        public void LoadForm(Form form)
        {
            mainPanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogInForm loginForm = new LogInForm();
            loginForm.Show();
            this.Close();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            LoadForm(new PaymentForm());
        }

        private void btnMemberShips_Click(object sender, EventArgs e)
        {
            LoadForm(new EmployeeForm());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadForm(new Home());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            int clientId = 2;
            var summary = _attendanceService.GetClientAttendanceSummary(clientId);
            if (summary != null)
            {
                ClientName.Text = summary.ClientName;
                Package.Text = summary.PackageName;
                JoinDate.Text = summary.JoinDate.ToString("dd MMM yyyy");
                EndDate.Text = summary.EndDate.ToString("dd MMM yyyy");
                TotalSessions.Text = summary.TotalSessions.ToString();
                AttendedSessions.Text = summary.AttendedSessions.ToString();
                Remaining.Text = summary.RemainingSessions.ToString();
                LastAttendance.Text = summary.LastAttendanceDate?.ToString("dd MMM yyyy") ?? "No Previous";
                CurrentTime.Text = summary.CurrentAttendanceTime.ToString("hh:mm tt");
            }
        }

        private void btnFAQ_Click(object sender, EventArgs e)
        {
            LoadForm(new FAQ());
        }
    }
}
