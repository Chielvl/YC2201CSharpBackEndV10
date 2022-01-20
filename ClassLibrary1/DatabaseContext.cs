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
        public DatabaseContext(DbContextOptions options) { }

        public DbSet<Gerecht> gerecht { get; set; }

    }
}
