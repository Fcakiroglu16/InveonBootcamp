using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Web.Models.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {
        public DbSet<UserFeature> UserFeatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserFeature>().Property(x => x.Gender).HasColumnName("gender");

            builder.Entity<UserFeature>().ToTable("user_feature");
            builder.Entity<UserFeature>().HasKey(x => x.UserId);

            base.OnModelCreating(builder);

            builder.Entity<UserFeature>().HasKey(x => x.UserId);

            builder.Entity<UserFeature>().HasOne(x => x.AppUser)
                .WithOne(x => x.UserFeature)
                .HasForeignKey<UserFeature>(x => x.UserId);
        }
    }
}