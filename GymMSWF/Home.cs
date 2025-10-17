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
    public partial class Home : Form
    {
        private readonly AttendanceService _attendanceService;

        public Home()
        {
            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _attendanceService = new AttendanceService(context);
        }
        private void Home_Load(object sender, EventArgs e)
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
    }
}
