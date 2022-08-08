using Microsoft.EntityFrameworkCore;

namespace IAZBackend.Models.ApsEntities
{
    public sealed class IAZ_ApsContext: DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Dataset> Orders_Dataset { get; set; } = null!;
        public DbSet<OrderLink> OrderLinks { get; set; } = null!;

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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) =>
            dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-30L35AH\\SQLEXPRESS;Database=IAZ Preactor;Trusted_Connection=True;");
    }
}
