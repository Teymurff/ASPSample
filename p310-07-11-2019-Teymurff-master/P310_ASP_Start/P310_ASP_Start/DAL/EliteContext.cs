using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P310_ASP_Start.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace P310_ASP_Start.DAL
{
    public class EliteContext : IdentityDbContext<ApplicationUser>
    {
        public EliteContext(DbContextOptions<EliteContext> options) : base(options) 
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<NewArrival> NewArrivals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slider>().HasData(
                new Slider { Id = 1, Image = "banner1.jpg", Title = "The Biggest <span>Sale</span> ", SubTitle = "Special for today" },
                new Slider { Id = 2, Image = "banner2.jpg", Title = "SUMMER <span>COLLECTION </span> ", SubTitle = "New Arrivals On Sale" },
                new Slider { Id = 3, Image = "banner3.jpg", Title = "The Biggest <span>Sale</span> ", SubTitle = "Special for Kamran" },
                new Slider { Id = 4, Image = "banner4.jpg", Title = "The Biggest <span>Perviz ever</span> ", SubTitle = "Special for Ruslan" }
            );

            modelBuilder.Entity<NewArrival>().HasData(
                new NewArrival { Id = 1, Image = "bottom1.jpg" ,Title = "<span>f</span>all ahead"},
                new NewArrival { Id = 2, Image = "bottom2.jpg" ,Title = "<span>f</span>all ahead" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1,  Name = "Men's" },
                new Category { Id = 2,  Name = "Women's" },
                new Category { Id = 3,  Name = "Bags" },
                new Category { Id = 4,  Name = "Footwear" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "T-short 1", Image = "w1.jpg", CategoryId = 1, CreatedAt = DateTime.Now, HasDiscount = false, Price = 100, DiscountedPrice = 0 },
                new Product { Id = 2, Name = "Bluse 1", Image = "w2.jpg", CategoryId = 2, CreatedAt = DateTime.Now, HasDiscount = false, Price = 120, DiscountedPrice = 0 },
                new Product { Id = 3, Name = "Shoes 2", Image = "w3.jpg", CategoryId = 2, CreatedAt = DateTime.Now, HasDiscount = false, Price = 150, DiscountedPrice = 0 },
                new Product { Id = 4, Name = "Short 3", Image = "w4.jpg", CategoryId = 3, CreatedAt = DateTime.Now, HasDiscount = false, Price = 155, DiscountedPrice = 0 }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //lazy loading activation
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
