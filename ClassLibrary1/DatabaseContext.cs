using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Gerecht> gerecht { get; set; }
        public DbSet<Product> producten{ get; set; }
        public DbSet<Voedingswaarden> voedingswaardens { get; set; }

    }
}
