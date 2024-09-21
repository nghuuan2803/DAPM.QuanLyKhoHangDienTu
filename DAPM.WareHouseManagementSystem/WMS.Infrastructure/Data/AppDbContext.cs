using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WMS.Domain;
using WMS.Domain.Entities.Authentication;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.PrivateEquipment;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        #region DbSet
        //Auth
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        //Product group
        public DbSet<Category> Categories { get; set; } //1
        public DbSet<Brand> Brands { get; set; } //2
        public DbSet<Suplier> Supliers { get; set; } //3
        public DbSet<Origin> Origins { get; set; } //4
        public DbSet<Product> Products { get; set; } //5
        public DbSet<Batch> Batches { get; set; } //6

        //Location storage
        //public DbSet<Warehouse> Warehouses { get; set; } //7
        //public DbSet<Zone> Zones { get; set; } //8
        //public DbSet<Shelf> Shelves { get; set; } //9

        //private equiment
        //public DbSet<PrivateEquipment> PrivateEquipments { get; set; } //10

        //organization
        //public DbSet<Employee> Employees { get; set; } //11
        //public DbSet<Partner> Partners { get; set; } //12

        //activities

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
