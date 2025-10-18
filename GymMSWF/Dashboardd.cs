using GymServices;
using Microsoft.EntityFrameworkCore.Internal;
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
    public partial class Dashboardd : Form
    {
        private readonly AttendanceService _attendanceService;
        private readonly FinanceService _financeService;

        public Dashboardd()
        {
            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _attendanceService = new AttendanceService(context);
            _financeService = new FinanceService(context);
        }

        private void Dashboard_load(object sender, EventArgs e)
        {

            LoadWeeklyAttendance();
            LoadLastAttendances();
            LoadPackages();
            LoadFinanceSummary();

        }

        private void LoadWeeklyAttendance()
        {
            Label[] dayLabels = { Day1, Day2, Day3, Day4, Day5, Day6, Day7 };
            Label[] countLabels = { Count1, Count2, Count3, Count4, Count5, Count6, Count7 };

            for (int i = 0; i < 7; i++)
            {
                DateTime targetDate = DateTime.Today.AddDays(-i);

                dayLabels[i].Text = targetDate.ToString("ddd");

                int count = _attendanceService.GetTodayAttendanceCount(targetDate);
                countLabels[i].Text = count.ToString();
            }
        }

        private void LoadLastAttendances()
        {
            var lastAttendances = _attendanceService.GetLastAttendances(4);

            Label[] names = { ClientName, ClientName2, ClientName3, ClientName4 };
            Label[] dates = { ClientDate, ClientDate2, ClientDate3, ClientDate4 };
            Label[] msgs = { ClientMs, ClientMs2, ClientMs3, ClientMs4 };

            for (int i = 0; i < lastAttendances.Count; i++)
            {
                var att = lastAttendances[i];
                var client = att.Client;

                if (client == null)
                    continue;

                int attendedCount = _attendanceService.GetAttendanceCountByClient(client.client_id);
                int packageSessions = client.Package?.pack_sessionsCount ?? 0;
                DateTime endDate = client.endDate;

                bool finishedBySessions = attendedCount >= packageSessions;
                bool finishedByTime = endDate < DateTime.Now;

                if (!finishedBySessions || !finishedByTime)
                {
                    names[i].Text = client.client_name;
                    dates[i].Text = att.AttendanceDate.ToString("dd/MM/yyyy");
                    msgs[i].Text = "Checked in successfully";
                }
                else
                {
                    names[i].Text = client.client_name;
                    dates[i].Text = DateTime.Today.ToString("dd/MM/yyyy");
                    msgs[i].Text = "Failed check-in No sessions left";
                }
            }
        }

        private void LoadPackages()
        {
            var packages = _attendanceService.GetAllPackagesWithInstructor();

            Label[] titles = { PackageTitle, PackageTitle1 };
            Label[] starts = { PackageStart, PackageStart1 };
            Label[] instructors = { PackageIns, PackageIns1 };

            for (int i = 0; i < titles.Length && i < packages.Count; i++)
            {
                var package = packages[i];

                titles[i].Text = package.PackageName;
                starts[i].Text = package.StartDate?.ToString("h:mm tt") ?? "N/A";
                instructors[i].Text = package.InstructorName;
            }
        }

        private void LoadFinanceSummary()
        {
            var summary = _financeService.GetMonthlyFinanceSummary();

            Scheduled.Text = $"{summary.Scheduled:C}";
            Paid.Text = $"{summary.Paid:C}";
            Overdue.Text = $"{summary.Overdue:C}";
        }

        private void ClearAttendanceGroup(int x)
        {
            Label[] names = { ClientName, ClientName2, ClientName3, ClientName4 };
            Label[] dates = { ClientDate, ClientDate2, ClientDate3, ClientDate4 };
            Label[] msgs = { ClientMs, ClientMs2, ClientMs3, ClientMs4 };
            Button[] buttons = { btnNext, btnNext2, btnNext3, btnNext4 };

            names[x].Text = "";
            dates[x].Text = "";
            msgs[x].Text = "";

            buttons[x].Visible = false;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            ClearAttendanceGroup(0);
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            ClearAttendanceGroup(1);
        }

        private void btnNext3_Click(object sender, EventArgs e)
        {
            ClearAttendanceGroup(2);
        }

        private void btnNext4_Click(object sender, EventArgs e)
        {
            ClearAttendanceGroup(3);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            Label[] names = { ClientName, ClientName2, ClientName3, ClientName4 };
            Label[] dates = { ClientDate, ClientDate2, ClientDate3, ClientDate4 };
            Label[] msgs = { ClientMs, ClientMs2, ClientMs3, ClientMs4 };
            Button[] buttons = { btnNext, btnNext2, btnNext3, btnNext4 };

            for (int i = 0; i < names.Length; i++)
            {
                names[i].Text = "";
                dates[i].Text = "";
                msgs[i].Text = "";
            }

            foreach (var btn in buttons)
            {
                btn.Visible = false;
            }
        }
    }
}
