using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace WebLab2.Controllers
{
    public class Detail
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int Adres { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<Detail> Details => Set<Detail>();
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Details.db");
        }
    }


    public class DetailDTO
    {
        public int Count { get; set; }
        public int Adres { get; set; }
    }

  
}
