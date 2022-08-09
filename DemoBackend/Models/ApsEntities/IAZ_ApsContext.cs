using Microsoft.EntityFrameworkCore;
using IAZBackend.Config;

namespace IAZBackend.Models.ApsEntities
{
    public sealed class IAZ_ApsContext: DbContext
    {
        private ConfigLoader config = new ConfigLoader();
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Dataset> Orders_Dataset { get; set; } = null!;
        public DbSet<OrderLink> OrderLinks { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("UserData");

            modelBuilder.Entity<OrderLink>()
                .HasOne(link => link.FromOrder)
                .WithMany()
                .HasForeignKey(link => link.FromInternalSupplyOrder);

            modelBuilder.Entity<OrderLink>()
                .HasOne(link => link.ToOrder)
                .WithMany()
                .HasForeignKey(link => link.ToInternalDemandOrder);
            
            modelBuilder.Entity<Order>()
                .HasOne(link => link.AssignedResource)
                .WithMany()
                .HasForeignKey(link => link.Resource);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) =>
            dbContextOptionsBuilder.UseSqlServer($"Server={config.SqlServer};Database=IAZ Preactor;Trusted_Connection=True;");
    }
}
