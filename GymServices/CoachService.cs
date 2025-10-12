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
    public class CoachService
    {
        private readonly GymContextDB _context;

        public CoachService(GymContextDB context)
        {
            _context = context;
        }

        public async Task<List<Coach>> GetAllCoaches()
        {
            return await _context.Coaches.ToListAsync();
        }

        public async Task<List<Coach>> GetCoaches( int id)
        {
            return await _context.Coaches.ToListAsync();
        }
    }
}
