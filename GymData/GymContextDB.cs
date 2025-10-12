using GymData.Models;
using Microsoft.EntityFrameworkCore;


namespace GymData
{
    public class GymContextDB : DbContext
    {
        public GymContextDB(DbContextOptions<GymContextDB> options) : base(options) { }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Finance> Finances { get; set; }
    }
}
