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

        public DbSet<Gerecht> Gerecht { get; set; }
        public DbSet<Voedingswaarden> Producten{ get; set; }
        public DbSet<Voedingswaarden> Voedingswaarden { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealsDishComponents> MealsDishComponents { get; set; }

    }
}
