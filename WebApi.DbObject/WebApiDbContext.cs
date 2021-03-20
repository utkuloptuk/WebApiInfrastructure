using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DbObject
{
    public class WebApiDbContext : DbContext
    {
        protected WebApiDbContext()
        {
        }
        public WebApiDbContext(DbContextOptions options):base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Method intentionally left empty.
        }
        public DbSet<User> User { get; set; }

    }
}
