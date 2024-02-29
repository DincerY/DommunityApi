using Dommunity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dommunity.Persistence.Contexts;

public class DommunityDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Community> Communities { get; set; }
    public DbSet<Organization> Organizations { get; set; }  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=DommunityDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Community>().HasKey(o => o.Id);
        builder.Entity<Organization>().HasKey(o => o.Id);
        builder.Entity<User>().HasKey(u => u.Id);

        //builder.Entity<Community>()
        //    .HasMany<Organization>()
        //    .WithOne(o => o.Community)
        //    .HasForeignKey(o => o.CommunityId);

        //builder.Entity<Organization>().HasKey(o => o.Id);

    }
}
