using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Context.EFCoreContext
{
    public class EFCoreContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<SaleHistory>? SaleHistories { get; set; }
        public DbSet<ProductDetail>? ProductDetails { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<PartTimeEmployee>? PartTimeEmployees { get; set; }
        public DbSet<FullTimeEmployee>? FullTimeEmployees { get; set; }
        public DbSet<Person>? People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AspEFCore;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluentApi - Employees Table
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployee");
            modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployee");
            #endregion
            
            #region FluentApi - Product Table
            modelBuilder.Entity<Product>().HasMany(x => x.SaleHistories).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);

            // modelBuilder.Entity<Product>().HasOne(x=>x.ProductDetails).WithOne(x=>x.Product).HasForeignKey<ProductDetail>(x=>x.ProductId);

            modelBuilder.Entity<Product>().HasMany(x => x.ProductCategories).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });


            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Product>().Property(x => x.name).IsRequired().HasMaxLength(30);
            // modelBuilder.Entity<Product>().HasIndex(x=>x.name).IsUnique();
            modelBuilder.Entity<Product>().Property(x => x.name).HasDefaultValueSql("'Ürün Adi Girilmemiş'");
            modelBuilder.Entity<Product>().Property(x => x.CreatingDate).HasDefaultValueSql("getdate()".ToString());
            modelBuilder.Entity<Product>().Property(x => x.price).IsRequired();
            #endregion

            #region FluentApi - Category Table
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(30).IsRequired();
            #endregion

            #region FluentApi - Customer Table
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().Property(x => x.Id).UseIdentityColumn();

            modelBuilder.Entity<Customer>().Property(x => x.name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Customer>().Property(x => x.lastname).IsRequired().HasMaxLength(40);
            #endregion
        }
    }
}