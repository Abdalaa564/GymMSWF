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
	public partial class AddPayment : Form
	{
		private readonly PaymentServices _paymentService;
		private readonly ClientServices _clientService;
		private readonly Payment? _existingPayment;

		public AddPayment()
		{
			InitializeComponent();
			var context = DbContext.CreateDbContext();
			_paymentService = new PaymentServices(context);
			_clientService = new ClientServices(context);
			nameClientCombo.SelectedIndexChanged += nameClientCombo_SelectedIndexChanged;
			this.Load += AddPayment_Load;
		}
		private async void AddPayment_Load(object? sender, EventArgs e)
		{
			await LoadClients();
		}


		public AddPayment(Payment payment)
		{
			InitializeComponent();
			var context = DbContext.CreateDbContext();
			_paymentService = new PaymentServices(context);
			_clientService = new ClientServices(context);
			_existingPayment = payment;
			nameClientCombo.SelectedIndexChanged += nameClientCombo_SelectedIndexChanged;
			LoadClientDataAsync(payment);
		}

		private async Task LoadClients()
		{
			var clients = await _clientService.GetAllClients();
            //nameClientCombo.DataSource = clients;
            //nameClientCombo.DisplayMember = "Name";
            //nameClientCombo.ValueMember = "Id";
            var clientsWithoutPayments = clients
                    .Where(c => string.IsNullOrEmpty(c.PaymentStatus))
                    .ToList();

            nameClientCombo.DataSource = clientsWithoutPayments;
            nameClientCombo.DisplayMember = "Name";
			nameClientCombo.ValueMember = "Id";

        }

		private async void LoadClientDataAsync(Payment payment)
		{
			await LoadClients();

            Addbtn.Text = "Update";
            Addbtn.FillColor = Color.FromArgb(2, 172, 195);
            AmountTxt.Text = payment.amount.ToString();
			PTypeCombo.Text = payment.payment_type;
			PStatusCombo.Text = payment.payment_status;
			CreatedAtTime.Value = payment.created_at;
			nameClientCombo.SelectedValue = payment.client_id;
		}

		private async void Addbtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (_existingPayment == null)
				{
					
					var newPayment = new GymData.Models.Payment
					{
						payment_type = PTypeCombo.Text,
						amount = decimal.Parse(AmountTxt.Text),
						payment_status = PStatusCombo.SelectedItem.ToString(),
						created_at = CreatedAtTime.Value.Date,
						client_id = (int)nameClientCombo.SelectedValue
					};

					await _paymentService.AddPayment(newPayment);
					MessageBox.Show("Payment added successfully!");
				}
				else
				{
					_existingPayment.payment_type = PTypeCombo.Text;
					_existingPayment.amount = decimal.Parse(AmountTxt.Text);
					_existingPayment.payment_status = PStatusCombo.SelectedItem.ToString();
					_existingPayment.created_at = CreatedAtTime.Value.Date;
					_existingPayment.client_id = (int)nameClientCombo.SelectedValue;

					await _paymentService.UpdatePayment(_existingPayment);
					MessageBox.Show("Payment updated successfully!");
				}

				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}

		private async void nameClientCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (nameClientCombo.SelectedValue is int clientId)
				{
					using (var context = DbContext.CreateDbContext())
					{
						var clientService = new ClientServices(context);
						var client = await clientService.GetClientById(clientId);

						if (client != null)
						{
							var package = await clientService.GetPackageById(client.pack_id);
							if (package != null)
							{
								AmountTxt.Text = package.pack_price.ToString("0.00");
								AmountTxt.ReadOnly = true;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading package price: {ex.Message}");
			}
		}
	}
}
