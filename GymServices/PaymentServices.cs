using GymData.Models;
using GymData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymServices
{
   public class PaymentServices
    {
		private readonly GymContextDB _context;

		public PaymentServices(GymContextDB context)
		{
			_context = context;
		}

		public async Task<List<Payment>> GetAllPayments()
		{
			return await _context.payment.Include(p => p.Client).ToListAsync();
		}

		public async Task AddPayment(Payment payment)
		{
			_context.payment.Add(payment);
			await _context.SaveChangesAsync();
		}
		public async Task<Payment?> GetPaymentById(int id)
		{
			return await _context.payment
				.Include(p => p.Client)
				.FirstOrDefaultAsync(p => p.payment_id == id);
		}

		public async Task DeletePayment(int id)
		{
			var payment = await _context.payment.FindAsync(id);
			if (payment != null)
			{
				_context.payment.Remove(payment);
				await _context.SaveChangesAsync();
			}
		}
		public async Task UpdatePayment(Payment payment)
		{
			_context.payment.Update(payment);
			await _context.SaveChangesAsync();
		}
	}
}

