using IShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Data
{
    public class AppDataContext : IdentityDbContext
    {
        public AppDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DiscountCard> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Items { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
