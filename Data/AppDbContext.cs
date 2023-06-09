public class AppDbContext : DbContext
{
    public DbSet<KYC> KYC { get; set; }
    public DbSet<Project> Project { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("YourConnectionStringHere");
    }
}
