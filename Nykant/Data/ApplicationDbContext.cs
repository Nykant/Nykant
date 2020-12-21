using Microsoft.EntityFrameworkCore;
using Nykant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nykant.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
