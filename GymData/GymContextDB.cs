using GymData.Models;
using Microsoft.EntityFrameworkCore;


namespace GymData
{
    public class GymContextDB : DbContext
    {
        public GymContextDB(DbContextOptions<GymContextDB> options) : base(options) { }

        public DbSet<Client> client { get; set; } = null!;
        public DbSet<Instructor> instructors { get; set; } = null!;
        public DbSet<Payment> payment { get; set; } = null!;
        public DbSet<Package> package { get; set; } = null!;
        public DbSet<Employee> employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔗 Client → Package (many-to-one)
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Package)
                .WithMany(p => p.Members)
                .HasForeignKey(c => c.pack_id)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔗 Payment → Client (many-to-one)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.client_id)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔗 Package → Instructor (many-to-one)
            modelBuilder.Entity<Package>()
                .HasOne(p => p.Instructor)
                .WithMany(i => i.Packages)
                .HasForeignKey(p => p.ins_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Package>()
                .Property(p => p.pack_price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.amount)
                .HasPrecision(18, 2);
        }

    }
}
