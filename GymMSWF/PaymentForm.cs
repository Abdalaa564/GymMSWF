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
	public partial class PaymentForm : Form
	{
		private readonly PaymentServices _paymentService;

		public PaymentForm()
		{
			InitializeComponent();

			var context = DbContext.CreateDbContext();
			_paymentService = new PaymentServices(context);
		}
		private async Task LoadPayments()
		{
			var payments = await _paymentService.GetAllPayments();


			var data = payments.Select(p => new
			{
				ID = p.payment_id,
				ClientName = p.Client != null ? p.Client.client_name : "N/A",
				Type = p.payment_type,
				Amount = p.amount,
				Date = p.created_at.ToString("yyyy-MM-dd"),
				Status = p.payment_status
			}).ToList();

			paymentData.DataSource = data;
		}
		private async void Payment_Load(object sender, EventArgs e)
		{
			await LoadPayments();
		}

		private async void Addbtn_Click(object sender, EventArgs e)
		{
			AddPayment addPayment = new AddPayment();
			addPayment.ShowDialog();
			await LoadPayments();
		}

		private async void SearchTxt_TextChanged(object sender, EventArgs e)
		{
			var payments = await _paymentService.GetAllPayments();
			var searchedText = SearchTxt.Text.ToLower();
			var filteredPayments = payments.Where(p => p.Client.client_name.ToLower().StartsWith(searchedText))
				.Select(p => new
				{
					ID = p.payment_id,
					ClientName = p.Client.client_name,
					Type = p.payment_type,
					Amount = p.amount,
					Date = p.created_at.ToString("yyyy-MM-dd"),
					Status = p.payment_status
				})
		.ToList();
			paymentData.DataSource = filteredPayments;
		}

		private async void Deletebtn_Click(object sender, EventArgs e)
		{
			if (paymentData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a payment to delete.");
				return;
			}


			int paymentId = Convert.ToInt32(paymentData.SelectedRows[0].Cells["ID"].Value);

			var confirm = MessageBox.Show("Are you sure you want to delete this payment?",
										  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (confirm == DialogResult.Yes)
			{
				await _paymentService.DeletePayment(paymentId);
				await LoadPayments();
				MessageBox.Show("Payment deleted successfully.");
			}
		}

		private async void Updatebtn_Click(object sender, EventArgs e)
		{
			if (paymentData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a payment to update.");
				return;
			}

			int paymentId = Convert.ToInt32(paymentData.SelectedRows[0].Cells["ID"].Value);

			var payment = await _paymentService.GetPaymentById(paymentId);
			if (payment == null)
			{
				MessageBox.Show("Payment not found.");
				return;
			}

			AddPayment updateForm = new AddPayment(payment); // نمرر الدفع للفورم
			updateForm.ShowDialog();

			await LoadPayments();
		}
	}
}
