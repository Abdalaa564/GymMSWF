using GymData.Models;
using GymData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymServices.Dtos;

namespace GymServices
{
   public class ClientServices
    {
		private readonly GymContextDB _context;

		public ClientServices(GymContextDB context)
		{
			_context = context;
		}


		public async Task<List<ClientDto>> GetAllClients()
		{
			//Ramiz
			return await _context.client
			   .Include(c => c.Package)
			   .Include(c => c.Payments)
			   .Select(s => new ClientDto
			   {
				   Id = s.client_id,
				   Name = s.client_name,
				   Gender = s.client_gender,
				   BirthDate = s.dateofBirth,
				   Phone = s.phone,
				   StartDate = s.startDate,
				   EndDate = s.endDate,
				   PackageTitle = s.Package.pack_title,
				   Paid = s.ispaid,
				   PaymentsAmount = string.Join(", ", s.Payments.Select(p => p.amount.ToString("C"))),
				   PaymentType = string.Join(", ", s.Payments.Select(p => p.payment_type))
			   })
			   .ToListAsync();
		} 
		public async Task<Client> AddClient(Client client)
		{
			if (client == null)
				throw new ArgumentNullException(nameof(client));
			await _context.client.AddAsync(client);
			await _context.SaveChangesAsync();
			return client;
		}
		public async Task<List<Package>> GetAllPackages()
		{
			return await _context.package.ToListAsync();
		}
		public async Task<Package?> GetPackageById(int id)
		{
			return await _context.package.FindAsync(id);
		}
		public async Task<Client?> GetClientById(int id)
		{
			return await _context.client
				.Include(c => c.Package)
				.Include(c => c.Payments)
				.FirstOrDefaultAsync(c => c.client_id == id);
		}

		public async Task DeleteClient(int id)
		{
			var client = await _context.client.FindAsync(id);
			if (client != null)
			{
				_context.client.Remove(client);
				await _context.SaveChangesAsync();
			}
		}
		public async Task UpdateClient(Client client)
		{
			var package = await _context.package.FindAsync(client.pack_id);
			client.Package = package;
			_context.client.Update(client);
			await _context.SaveChangesAsync();
		}
	}
}
