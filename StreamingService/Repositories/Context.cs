using Microsoft.EntityFrameworkCore;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public Context()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=StreamingService;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Subscription>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Subscription)
                .WithMany()
                .HasForeignKey(x => x.SubscriptionId);
        }
    }
}
