using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkaMonitorTWO.DB_classes
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Source> Sources{ get; set; } = null!;
        public DbSet<Emission> Emissions{ get; set; } = null!;
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ngknn.ru;Database=BabkaMonitor;User Id=33П;Password=12357;");
        }
    }
}
