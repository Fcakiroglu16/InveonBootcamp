using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Web.Models.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserFeature>().HasKey(x => x.UserId);

            builder.Entity<UserFeature>().HasOne(x => x.AppUser)
                .WithOne(x => x.UserFeature)
                .HasForeignKey<UserFeature>(x => x.UserId);
        }
    }
}