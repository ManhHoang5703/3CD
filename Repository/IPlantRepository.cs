using WebsitePlant.Models;
namespace WebsitePlant.Repository
{
    public interface IPlantRepository
    {      
        Task<IEnumerable<Plant>> GetAllAsync();
        Task<Plant> GetByIdAsync(int id);
        Task AddAsync(Plant plant);
        Task UpdateAsync(Plant plant);
        Task DeleteAsync(int id);
    }
}
