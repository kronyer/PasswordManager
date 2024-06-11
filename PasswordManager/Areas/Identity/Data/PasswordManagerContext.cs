using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Areas.Identity.Data;
using PasswordManager.Models;

namespace PasswordManager.Data;

public class PasswordManagerContext : IdentityDbContext<PasswordManagerUser>
{
    public DbSet<Password> Passwords { get; set; }

    public PasswordManagerContext(DbContextOptions<PasswordManagerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Password>()
            .HasOne(p => p.User)
            .WithMany(u => u.Passwords)
            .HasForeignKey(p => p.UserId);
    }
}
