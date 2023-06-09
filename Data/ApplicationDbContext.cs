using Microsoft.EntityFrameworkCore;
using YourApplication.Models;

namespace YourApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<KYC> KYC { get; set; }
        public DbSet<Project> Project { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne(p => p.KYC)
                .WithMany()
                .HasForeignKey(p => p.KYCID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
