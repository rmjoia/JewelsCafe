using JewelsCafe.Models;
using JewelsCafe.Repositories;

namespace JewelsCafe.Services
{
    public class MenuService
    {
        private readonly GenericRepository<Beverege> _beverageRepository;
        private readonly GenericRepository<Food> _foodRepository;

        MenuService(GenericRepository<Beverege> beverageRepository, GenericRepository<Food> foodRepository)
        {
            _beverageRepository = beverageRepository;
            _foodRepository = foodRepository;
        }
        
    }
}
