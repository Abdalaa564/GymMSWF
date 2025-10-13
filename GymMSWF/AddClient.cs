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
	public partial class AddClient : Form
	{
		private readonly ClientServices _clientService;
		private readonly Client? _existingClient;
		public AddClient(Client? client = null)
		{
			InitializeComponent();

			var context = DbContext.CreateDbContext();
			_clientService = new ClientServices(context);

			LoadPackages();
			_existingClient = client;

			if (_existingClient != null)
				LoadClientData();

		}
		private void LoadClientData()
		{
			nameTxt.Text = _existingClient.client_name;
			genderCombo.SelectedItem = _existingClient.client_gender;
			DataOfBTime.Value = _existingClient.dateofBirth;
			phoneTxt.Text = _existingClient.phone;
			startDateTime.Value = _existingClient.startDate;
			endDateTime.Value = _existingClient.endDate;
			packagecombo.SelectedValue = _existingClient.pack_id;
			paidRadio.Checked = _existingClient.ispaid;
		}

		private async void LoadPackages()
		{
			
			var packages = await _clientService.GetAllPackages(); 
			packagecombo.DataSource = packages;
			packagecombo.DisplayMember = "pack_title";
			packagecombo.ValueMember = "pack_id";
		}
		private async void Addbtn_Click(object sender, EventArgs e)
		{
			if (_existingClient != null)
			{
				
				_existingClient.client_name = nameTxt.Text;
				_existingClient.client_gender = genderCombo.SelectedItem?.ToString() ?? "M";
				_existingClient.dateofBirth = DataOfBTime.Value;
				_existingClient.phone = phoneTxt.Text;
				_existingClient.startDate = startDateTime.Value;
				_existingClient.endDate = endDateTime.Value;
				_existingClient.pack_id = (int)packagecombo.SelectedValue;
				_existingClient.ispaid = paidRadio.Checked;

				await _clientService.UpdateClient(_existingClient);
			}
			else
			{
				
				var client = new Client
				{
					client_name = nameTxt.Text,
					client_gender = genderCombo.SelectedItem?.ToString() ?? "M",
					dateofBirth = DataOfBTime.Value,
					phone = phoneTxt.Text,
					startDate = startDateTime.Value,
					endDate = endDateTime.Value,
					ispaid = paidRadio.Checked,
					pack_id = (int)packagecombo.SelectedValue
				};

				await _clientService.AddClient(client);
			}

			MessageBox.Show("Client saved successfully!");
			this.Close();
		}
	}
	}

