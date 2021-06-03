using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Database
{
    public class TecH3ProjectDbContext : DbContext
    {
        public TecH3ProjectDbContext() { }
        public TecH3ProjectDbContext(DbContextOptions<TecH3ProjectDbContext> options) : base(options) { }


        public DbSet<LogIn> LogIn { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Product_Property> Product_Property { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<Domain.Type> Type { get; set; }

    }
}
