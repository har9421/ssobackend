using Microsoft.EntityFrameworkCore;
using SSO.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SSO.Infrastructure.Data;

public class SSODbContext : IdentityDbContext
{
    public SSODbContext(DbContextOptions opt) : base(opt)
    {
    }
    public DbSet<User> Identities { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().ToTable("identity");
        base.OnModelCreating(builder);
    }
}
