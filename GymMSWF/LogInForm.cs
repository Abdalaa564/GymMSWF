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
    public partial class LogInForm : Form
    {
        private readonly LogInService _loginService;

        public LogInForm()
        {
            InitializeComponent();
            var context = DbContext.CreateDbContext(); 
            _loginService = new LogInService(context);

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = userNameText.Text.Trim();
            string password = passTextBox.Text.Trim();

            var employee = _loginService.Login(username, password);

            if (employee != null)
            {
                Dashboard dashboard = new Dashboard(employee.role == "Admin"); 
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.");
            }
        }
    }
}
