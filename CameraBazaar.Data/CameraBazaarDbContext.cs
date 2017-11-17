namespace CameraBazaar.Data
{
    using CameraBazaar.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CameraBazaarDbContext : IdentityDbContext<User>
    {
        public CameraBazaarDbContext(DbContextOptions<CameraBazaarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(c => c.Cameras)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId);

            base.OnModelCreating(builder);
        }
    }
}
