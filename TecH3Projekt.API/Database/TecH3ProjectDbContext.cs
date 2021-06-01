using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Database
{
    public class TecH3ProjectDbContext : DbContext
    {
        public TecH3ProjectDbContext() { }
        public TecH3ProjectDbContext(DbContextOptions<TecH3ProjectDbContext> options) : base(options) { }


        public DbSet<LogIn> LogIn { get; set; }

    }
}
