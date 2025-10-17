using GymData;
using GymData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices
{
   public class EmployeeServices
    {
		private readonly GymContextDB _context;
		public EmployeeServices(GymContextDB context)
		{
			_context = context;
		}

		public async  Task<List<Employee>> GetAll()
		{
			return await _context.employees.ToListAsync();
		}
		public async Task<Employee> Add(Employee employee)
		{
			await _context.employees.AddAsync(employee);
			await _context.SaveChangesAsync();
			return employee;
		}
		public async Task<bool> Delete(int rep_id)
		{
			var employee = await _context.employees.FindAsync(rep_id);
			if (employee == null)
				return false;

			_context.employees.Remove(employee);
			await _context.SaveChangesAsync();
			return true;
		}
		public async Task<Employee?> GetById(int id)
		{
			return await _context.employees.FirstOrDefaultAsync(e => e.rep_id == id);
		}
		public async Task<bool> Update(Employee emp)
		{
			if (emp == null)
				return false;

			_context.employees.Update(emp);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
