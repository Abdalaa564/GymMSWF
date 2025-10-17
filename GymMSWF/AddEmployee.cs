using GymData.Models;
using GymMSWF;
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
using System.Xml.Linq;

namespace GymMSWF
{
	public partial class AddEmployee : Form
	{
		private readonly EmployeeServices _employeeService;
		private readonly Employee? _existingEmployee;

		public AddEmployee(Employee? employee = null)
		{
			InitializeComponent();

			var context = DbContext.CreateDbContext();
			_employeeService = new EmployeeServices(context);

			_existingEmployee = employee;

			if (_existingEmployee != null)
			{
				LoadEmployeeData();
				Addbtn.Text = "Update";
				Addbtn.BackColor = ColorTranslator.FromHtml("#00BCD4");
			}
		}

		private void LoadEmployeeData()
		{
			nameTxt.Text = _existingEmployee.rep_name;
			PhoneTxt.Text = _existingEmployee.rep_phone;
			AddressTxt.Text = _existingEmployee.rep_address;
			genderCombo.SelectedItem = _existingEmployee.rep_gender;
			DataOfBTime.Value = _existingEmployee.rep_birthDate;
			UserNameTxt.Text = _existingEmployee.user_name;
			PasswordTxt.Text = _existingEmployee.rep_pass;
			RoleCombo.SelectedItem = _existingEmployee.role;
		}

		private async void Addbtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (_existingEmployee != null)
				{
					
					_existingEmployee.rep_name = nameTxt.Text;
					_existingEmployee.rep_phone = PhoneTxt.Text;
					_existingEmployee.rep_address = AddressTxt.Text;
					_existingEmployee.rep_gender = genderCombo.SelectedItem?.ToString() ?? "M";
					_existingEmployee.rep_birthDate = DataOfBTime.Value;
					_existingEmployee.user_name = UserNameTxt.Text;
					_existingEmployee.rep_pass = PasswordTxt.Text;
					_existingEmployee.role = RoleCombo.SelectedItem?.ToString() ?? "Employee";

					bool updated = await _employeeService.Update(_existingEmployee);
					if (updated)
						MessageBox.Show("Employee updated successfully!");
					else
						MessageBox.Show("Update failed! Employee not found.");
				}
				else
				{
					
					var emp = new Employee
					{
						rep_name = nameTxt.Text,
						rep_phone = PhoneTxt.Text,
						rep_address = AddressTxt.Text,
						rep_gender = genderCombo.SelectedItem?.ToString() ?? "M",
						rep_birthDate = DataOfBTime.Value,
						user_name = UserNameTxt.Text,
						rep_pass = PasswordTxt.Text,
						role = RoleCombo.SelectedItem?.ToString() ?? "Employee"
					};

					await _employeeService.Add(emp);
					MessageBox.Show("Employee added successfully!");
				}

				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}
	}
}



