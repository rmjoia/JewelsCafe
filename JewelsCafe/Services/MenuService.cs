using JewelsCafe.Models;
using JewelsCafe.Repositories;

namespace JewelsCafe.Services
{
    public class MenuService
    {
        private readonly GenericRepository<Beverage> _beverageRepository;
        private readonly GenericRepository<Food> _foodRepository;

        MenuService(GenericRepository<Beverage> beverageRepository, GenericRepository<Food> foodRepository)
        {
            _beverageRepository = beverageRepository;
            _foodRepository = foodRepository;
        }
        
    }
}
