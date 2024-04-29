using Microsoft.EntityFrameworkCore;
namespace WebsitePlant.Models
{
   
        public class PlantDbContext : DbContext
        {

            public PlantDbContext(DbContextOptions<PlantDbContext> options) : base(options)

            {

            }
            public DbSet<Plant> Plants { get; set; }
            public DbSet<PlantImage> PlantImages { get; set; }

        }

}
