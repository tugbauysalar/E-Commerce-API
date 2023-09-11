using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence
{
    //Veritabanı işlemlerini yapmak için DbContext sınıfından kalıtılmış AppDbContext sınıfı oluşturuldu.  
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        //Veritabanı bağlantısı için constructor oluşturuldu.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        //Veritabanında kategori ve ürün için tablo oluşturuldu. 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }
   
        //Veritabanı tablolarının ilişkilerini yapılandırmak için 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entitiy konfigürasyonlarını uygulamak için bu method kullanıldı.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            //seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", CreatedDate = new DateTime(1,1,1,1,1,1,1,1,DateTimeKind.Utc)},
                new Category { Id = 2, Name = "Fashion", CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc)},
                new Category { Id = 3, Name = "Jewelry", CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc)});

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Laptop", Price = 15000, Stock = 10, CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc)},
                new Product { Id = 2, CategoryId = 1, Name = "Phone", Price = 8000, Stock = 15 , CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc)},
                new Product { Id = 3, CategoryId = 2, Name = "Dress", Price = 500, Stock = 6 , CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc)},
                new Product { Id = 4, CategoryId = 2, Name = "Skirt", Price = 600, Stock = 8 , CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc)},
                new Product { Id = 5, CategoryId = 3, Name = "Ring", Price = 100, Stock = 20 , CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc)},
                new Product { Id = 6, CategoryId = 3, Name = "Watch", Price = 1500, Stock = 12 , CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc)}
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}