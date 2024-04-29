using Microsoft.EntityFrameworkCore;
using WebsitePlant.Models;
namespace WebsitePlant.Repository

{
    public class EFPlantRepository : IPlantRepository
    {
        private readonly PlantDbContext _context;

        public EFPlantRepository(PlantDbContext context)

        {
            _context = context;
        }

        public async Task<IEnumerable<Plant>> GetAllAsync()
        {
            return await _context.Plants.ToListAsync();
        }


        public async Task<Plant> GetByIdAsync(int id)
        {
            return await _context.Plants.SingleOrDefaultAsync(x => x.PlantId == id);
        }

        public async Task AddAsync(Plant plant)

        {

            _context.Plants.Add(plant);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Plant plant)

        {

            _context.Plants.Update(plant);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)

        {

            var plant = await _context.Plants.FindAsync(id);
            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

        }

    }
}
