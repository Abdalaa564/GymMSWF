using GymData;
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
	public partial class ClientPage : Form
	{
		private readonly ClientServices _clientService;

		public ClientPage()
		{
			InitializeComponent();

			var context = DbContext.CreateDbContext();

			_clientService = new ClientServices(context);
		}


		private async Task LoadClients()
		{
			var clients = await _clientService.GetAllClients();
			ClientData.DataSource = clients
					.GroupBy(c => c.Id)
					.Select(g => g.First())
					.ToList();
			ClientData.Columns["BirthDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
			ClientData.Columns["StartDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
			ClientData.Columns["EndDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
		}

		private async void ClientPage_Load(object sender, EventArgs e)
		{
			await LoadClients();
		}

		private async void SearchTxt_TextChanged(object sender, EventArgs e)
		{
			var clients = await _clientService.GetAllClients();
			var searchedText = SearchTxt.Text.ToLower();
			var filteredClients = clients.Where(c => c.Name.ToLower().StartsWith(searchedText));
			ClientData.DataSource = filteredClients.ToList();
		}

		private async void Addbtn_Click(object sender, EventArgs e)
		{
			AddClient addClient = new AddClient();

			addClient.ShowDialog();

			await LoadClients();
		}

		private async void Deletebtn_Click(object sender, EventArgs e)
		{
			if (ClientData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a client to delete.");
				return;
			}

			int clientId = Convert.ToInt32(ClientData.SelectedRows[0].Cells["Id"].Value);

			var confirm = MessageBox.Show("Are you sure you want to delete this client?",
										  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (confirm == DialogResult.Yes)
			{
				await _clientService.DeleteClient(clientId);
				await LoadClients();
				MessageBox.Show("Client deleted successfully.");
			}
		}

		private async void Updatebtn_Click(object sender, EventArgs e)
		{
			if (ClientData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a client to update.");
				return;
			}

			int clientId = Convert.ToInt32(ClientData.SelectedRows[0].Cells["Id"].Value);

			var client = await _clientService.GetClientById(clientId);
			if (client == null)
			{
				MessageBox.Show("Client not found.");
				return;
			}

			AddClient updateForm = new AddClient(client); 
			updateForm.ShowDialog();

			await LoadClients();
		}
	}
}
