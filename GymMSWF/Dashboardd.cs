using GymData.Models;
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


        private List<Attendance> _lastAttendancesCache = new List<Attendance>();

        private void LoadLastAttendances()
        {
            flowAttendances.Controls.Clear();
            _lastAttendancesCache = _attendanceService.GetLastAttendances(20);

            Panel headerPanel = new Panel();
            headerPanel.Width = flowAttendances.ClientSize.Width - 10;
            headerPanel.Height = 35;
            headerPanel.BackColor = Color.WhiteSmoke;
            headerPanel.Margin = new Padding(5);

            Label lblNotifi = new Label();
            lblNotifi.Text = "Notifications";
            lblNotifi.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblNotifi.Location = new Point(35, 5);
            lblNotifi.AutoSize = true;
            lblNotifi.ForeColor = Color.Teal;

            Button btnSortByStatus = new Button();
            btnSortByStatus.Text = "Sort by Status";
            btnSortByStatus.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            btnSortByStatus.Size = new Size(90, 28);
            btnSortByStatus.Location = new Point(140, 4);
            btnSortByStatus.BackColor = Color.White;
            btnSortByStatus.FlatStyle = FlatStyle.Standard;
            btnSortByStatus.FlatAppearance.BorderSize = 1;

            Button btnSortByDate = new Button();
            btnSortByDate.Text = "Sort by Date";
            btnSortByDate.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            btnSortByDate.Size = new Size(90, 28);
            btnSortByDate.Location = new Point(btnSortByStatus.Right + 15, 4);
            btnSortByDate.BackColor = Color.White;
            btnSortByDate.FlatStyle = FlatStyle.Standard;
            btnSortByDate.FlatAppearance.BorderSize = 1;

            //Button btnClearAll = new Button();
            //btnClearAll.Text = "DISMISS All";
            //btnClearAll.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            //btnClearAll.Size = new Size(90, 28);
            //btnClearAll.Location = new Point(btnSortByDate.Right + 15, 4);
            //btnClearAll.BackColor = Color.White;
            //btnClearAll.FlatStyle = FlatStyle.Standard;
            //btnClearAll.FlatAppearance.BorderSize = 1;
            //btnClearAll.Click += (s, e) =>
            //{
            //    flowAttendances.Controls.Clear();
            //    flowAttendances.Controls.Add(headerPanel);
            //};

            Button btnClearFailed = new Button();
            btnClearFailed.Text = "Clear Failed";
            btnClearFailed.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            btnClearFailed.Size = new Size(100, 28);
            btnClearFailed.Location = new Point(btnSortByDate.Right + 15, 4);
            btnClearFailed.BackColor = Color.White;
            btnClearFailed.FlatStyle = FlatStyle.Standard;
            btnClearFailed.FlatAppearance.BorderSize = 1;

            btnClearFailed.Click += (s, e) =>
            {
                // خزن كل البانلز اللي فيها رسالة فاشلة
                var toRemove = flowAttendances.Controls
                    .OfType<Panel>()
                    .Where(p => p.Controls.OfType<Label>()
                        .Any(lbl => lbl.Text.Contains("Failed check-in")))
                    .ToList();

                foreach (var panel in toRemove)
                {
                    flowAttendances.Controls.Remove(panel);
                    panel.Dispose();
                }
            };

            // زرار حذف كل الرسائل الناجحة (Checked in successfully)
            Button btnClearSuccess = new Button();
            btnClearSuccess.Text = "Clear Success";
            btnClearSuccess.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            btnClearSuccess.Size = new Size(110, 28);
            btnClearSuccess.Location = new Point(btnClearFailed.Right + 15, 4);
            btnClearSuccess.BackColor = Color.White;
            btnClearSuccess.FlatStyle = FlatStyle.Standard;
            btnClearSuccess.FlatAppearance.BorderSize = 1;

            btnClearSuccess.Click += (s, e) =>
            {
                var toRemove = flowAttendances.Controls
                    .OfType<Panel>()
                    .Where(p => p.Controls.OfType<Label>()
                        .Any(lbl => lbl.Text.Contains("Checked in successfully")))
                    .ToList();

                foreach (var panel in toRemove)
                {
                    flowAttendances.Controls.Remove(panel);
                    panel.Dispose();
                }
            };

            headerPanel.Controls.Add(lblNotifi);
            headerPanel.Controls.Add(btnSortByStatus);
            headerPanel.Controls.Add(btnSortByDate);
            //headerPanel.Controls.Add(btnClearAll);
            headerPanel.Controls.Add(btnClearFailed);
            headerPanel.Controls.Add(btnClearSuccess);

            flowAttendances.Controls.Add(headerPanel);

            // =====================================

            DisplayAttendances(_lastAttendancesCache);

            btnSortByStatus.Click += (s, e) =>
            {
                var sorted = _lastAttendancesCache.OrderByDescending(a =>
                {
                    var client = a.Client;
                    if (client == null) return 0;

                    int attendedCount = _attendanceService.GetAttendanceCountByClient(client.client_id);
                    int packageSessions = client.Package?.pack_sessionsCount ?? 0;
                    DateTime endDate = client.endDate;

                    bool unlimited = packageSessions == 0;
                    bool withinSessions = unlimited || attendedCount <= packageSessions;
                    bool withinTime = endDate.Date >= DateTime.Today;

                    bool success = withinSessions && withinTime;
                    return success ? 1 : 0;
                }).ToList();

                flowAttendances.Controls.Clear();
                flowAttendances.Controls.Add(headerPanel);
                DisplayAttendances(sorted);
            };

            btnSortByDate.Click += (s, e) =>
            {
                var sorted = _lastAttendancesCache
                    .OrderByDescending(a => a.AttendanceDate)
                    .ToList();

                flowAttendances.Controls.Clear();
                flowAttendances.Controls.Add(headerPanel);
                DisplayAttendances(sorted);
            };
        }


        private void DisplayAttendances(List<Attendance> attendances)
        {
            foreach (var att in attendances)
            {
                var client = att.Client;
                if (client == null) continue;

                int attendedCount = _attendanceService.GetAttendanceCountByClient(client.client_id);
                int packageSessions = client.Package?.pack_sessionsCount ?? 0;
                DateTime endDate = client.endDate;

                bool unlimitedSessions = packageSessions == 0;
                bool withinSessions = unlimitedSessions ? true : attendedCount <= packageSessions;
                bool withinTime = endDate.Date >= DateTime.Today;

                Panel p = new Panel();
                p.Width = 350;
                p.Height = 55;
                p.BackColor = Color.WhiteSmoke;
                p.BorderStyle = BorderStyle.None;
                p.Margin = new Padding(5);
                p.ForeColor = Color.Teal;
                p.Font = new Font("Times New Roman", 12, FontStyle.Bold);

                Label lblName = new Label();
                lblName.Text = client.client_name;
                lblName.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                lblName.Location = new Point(10, 5);
                lblName.AutoSize = true;
                lblName.ForeColor = Color.Teal;

                Label lblDate = new Label();
                lblDate.Text = att.AttendanceDate.ToString("dd/MM/yyyy hh:mm tt");
                lblDate.Font = new Font("Times New Roman", 11, FontStyle.Bold);
                lblDate.ForeColor = Color.Teal;
                lblDate.Location = new Point(10, 25);
                lblDate.AutoSize = true;

                Label lblMsg = new Label();
                lblMsg.AutoSize = true;
                lblMsg.Location = new Point(200, 13);
                lblMsg.Font = new Font("Times New Roman", 11, FontStyle.Bold);

                if (withinSessions && withinTime)
                {
                    lblMsg.Text = "✅ Checked in successfully";
                    lblMsg.ForeColor = Color.ForestGreen;
                }
                else
                {
                    lblMsg.Text = "⚠️ Failed check-in No sessions left";
                    lblMsg.ForeColor = Color.DarkRed;
                }

                Button btnRemove = new Button();
                btnRemove.Text = "DISMISS";
                btnRemove.Font = new Font("Times New Roman", 9, FontStyle.Bold);
                btnRemove.ForeColor = Color.Black;
                btnRemove.BackColor = Color.White;
                btnRemove.FlatStyle = FlatStyle.Standard;
                btnRemove.FlatAppearance.BorderSize = 1;
                btnRemove.Size = new Size(80, 23);
                btnRemove.Location = new Point(p.Width - btnRemove.Width - 6, 6);
                btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                btnRemove.Click += (s, e) =>
                {
                    flowAttendances.Controls.Remove(p);
                    p.Dispose();
                };

                Panel separator = new Panel();
                separator.Height = 2;
                separator.Dock = DockStyle.Bottom;
                separator.BackColor = Color.LightGray;

                p.Controls.Add(lblName);
                p.Controls.Add(lblDate);
                p.Controls.Add(lblMsg);
                p.Controls.Add(btnRemove);
                p.Controls.Add(separator);

                flowAttendances.Resize += (s, e) => { p.Width = flowAttendances.ClientSize.Width - 10; };
                p.Width = flowAttendances.ClientSize.Width - 10;

                flowAttendances.Controls.Add(p);
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

    }
}
