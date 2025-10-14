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
    public class PackageService
    {
        private readonly GymContextDB _context;

        public PackageService(GymContextDB context)
        {
            _context = context;
        }

        public async Task<List<Package>> GetAllPackages()
        {
            return await _context.package.ToListAsync();
        }
        public async Task AddPackageAsync(Package package)
        {
            _context.package.Add(package);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePackageAsync(Package package)
        {
            _context.package.Update(package);
            await _context.SaveChangesAsync();
        }
        public Package GetPackageById(int id)
        {
            return _context.package
                .Include(p => p.Instructor)
                .FirstOrDefault(p => p.pack_id == id);
        }
        public async Task DeletePackageAsync(int id)
        {
            var pkg = GetPackageById(id);
            if (pkg != null)
            {
                _context.package.Remove(pkg);
                await _context.SaveChangesAsync();
            }
        }

    }
}
