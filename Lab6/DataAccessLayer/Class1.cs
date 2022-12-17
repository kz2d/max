using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
        : base()
    {
        Database.EnsureCreated();
        Database.Migrate();
        // Database.AutoSavepointsEnabled = true;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=lol.db");
    }

    public DbSet<Worker> Worker { get; set; }
    public DbSet<Sms> Sms { get; set; }
    public DbSet<Messager> Messager { get; set; }
    public DbSet<Email> Email { get; set; }
    public DbSet<Otchet> Otchet { get; set; }
    
    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }
}