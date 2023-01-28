using JewelsCafe.Models;
using JewelsCafe.Repositories;

namespace JewelsCafe.ViewModels
{
    public partial class CoffeeListViewModel : ViewModelBase
    {
        private readonly GenericRepository<Beverege> _genericRepository;

        public CoffeeListViewModel(GenericRepository<Beverege> genericRepository)
        {
            _genericRepository = genericRepository;
            
            InitializeBeverageRepository();
        }

        private void InitializeBeverageRepository()
        {
            var beverages = new List<IFood>
        {
            new Beverege {
                Id =  Guid.NewGuid(),
                Name = "Coca Cola",
                Description = "Tastes Funny",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id = Guid.NewGuid(), Name = "Sugar", IsAlergen = true },
                    new Ingredient { Id = Guid.NewGuid(), Name = "Caramel", IsAlergen =false },
                    new Ingredient { Id = Guid.NewGuid(), Name = "Secret mixture", IsAlergen = false }
                },
                IsOptionAvailable= true,
                IsSignature = false,
                Options = new List<string>{"Diet","Zero","Cherry","No Caffeine"},
                Type = BestServeType.Cold
            },
            new Beverege {
            Id = Guid.NewGuid(),
            Name = "Jewel's Roast Coffee",
            Description = "Dark custom blend of arabian selected coffee and a mixture of spices",
            Ingredients = new List<Ingredient> {
                    new Ingredient { Id = Guid.NewGuid(), Name = "Coffee", IsAlergen = false },
                    new Ingredient { Id = Guid.NewGuid(), Name = "mixture of oriental spices", IsAlergen =false },
                },
            IsOptionAvailable = true,
            IsSignature = false,
            Options = new List<string> { "Milk", "Almond Milk", "Oat Milk", "Coconut Milk" },
            Type = BestServeType.Hot
            }
        };

            _genericRepository.Add(beverages);
        }
    }
}
