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
        public DbSet<SecConstraint> SecConstraints { get; set; } = null!;
        public DbSet<OrderSecConstraint> OrderSecConstraints { get; set; } = null!;
        public DbSet<Workgroup> Workgroups { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(ord => new { ord.OrderId, ord.DatasetId });

            modelBuilder.Entity<Order>()
                .HasOne(ord => ord.Resource)
                .WithMany(res => res.Orders)
                .HasForeignKey(ord => ord.ResourceId);

            modelBuilder.Entity<OrderLink>()
                .HasKey(ol => new { ol.DatasetId, ol.FromOrderId, ol.ToOrderId });

            modelBuilder.Entity<OrderLink>()
                .HasOne(link => link.FromOrder)
                .WithMany(ord => ord.LinksFrom)
                .HasForeignKey(link => new { link.FromOrderId, link.DatasetId })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderLink>()
                .HasOne(link => link.ToOrder)
                .WithMany(ord => ord.LinksTo)
                .HasForeignKey(link => new { link.ToOrderId, link.DatasetId })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderSecConstraint>()
                .HasKey(osc => new { osc.DatasetId, osc.OrderId, osc.SecConstraintId, osc.StartTime });

            modelBuilder.Entity<OrderSecConstraint>()
                .HasOne(osc => osc.Order)
                .WithMany(ord => ord.OrderSecConstraints)
                .HasForeignKey(osc => new { osc.OrderId, osc.DatasetId })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderSecConstraint>()
                .HasOne(osc => osc.SecConstraint)
                .WithMany()
                .HasForeignKey(osc => osc.SecConstraintId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) =>
            dbContextOptionsBuilder.UseSqlServer($"Server={config.SqlServer};Database=IAZ Preactor;Trusted_Connection=True;MultipleActiveResultSets=True;")
            .UseLazyLoadingProxies();
    }
}
