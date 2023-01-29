using CommunityToolkit.Mvvm.Input;
using JewelsCafe.Models;
using JewelsCafe.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace JewelsCafe.ViewModels
{
    [QueryProperty(nameof(Food.Id), "Id")]
    public partial class CoffeeListViewModel : ViewModelBase
    {
        private readonly GenericRepository<Beverage> _coffeeRepository;
        private ILogger<CoffeeListViewModel> _logger;

        public CoffeeListViewModel(GenericRepository<Beverage> genericRepository, ILogger<CoffeeListViewModel> logger)
        {
            Title = "Try our Selected Blends...";
            _coffeeRepository = genericRepository;
            _logger = logger;

            InitializeBeverageRepository();
            GetCoffeeList();
        }

        public ObservableCollection<Beverage> CoffeeList { get; private set; }


        private void InitializeBeverageRepository()
        {
            var beverages = new List<IFood>
        {
            new Beverage {
                Id =  Guid.NewGuid(),
                Name = "Coca Cola",
                Description = "Tastes Funny",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id = Guid.NewGuid(), Name = "Sugar", IsAlergen = true },
                    new Ingredient { Id = Guid.NewGuid(), Name = "Caramel", IsAlergen = false },
                    new Ingredient { Id = Guid.NewGuid(), Name = "Secret mixture", IsAlergen = false }
                },
                IsOptionAvailable= true,
                IsSignature = false,
                Options = new List<string>{"Diet","Zero","Cherry","No Caffeine"},
                BestServed = BestServeType.Cold,
                Family = FoodFamily.Soda
            },
            new Beverage {
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
            BestServed = BestServeType.Hot,
            Family = FoodFamily.Coffee
            }
        };

            _coffeeRepository.Add(beverages);
        }

        void GetCoffeeList()
        {
            if (IsLoading)
            {
                return;
            }
            try
            {
                CoffeeList = new();
                IsLoading = true;
                _coffeeRepository
                    .GetAll()
                    .Where(beverage => beverage.Family == FoodFamily.Coffee)
                    .ToList()
                    .ForEach(coffee => CoffeeList.Add((coffee as Beverage)));
            }
            catch (Exception ex)
            {
                _logger.LogError("an error has occurred while getting the coffee list!", ex.Message);
                //await Shell.Current.DisplayAlert("Error", "Something bad happened while getting the coffee list!", "OK");
            }
            finally
            {
                IsLoading = false;
            }

#pragma warning disable CS8321 // Local function is declared but never used (used in xaml)
            [RelayCommand]
            async Task AddToCartAsync()
            {
                _logger.LogDebug($"Here");

                try
                {

                }
                catch (Exception)
                {
                    await Shell.Current.DisplayAlert("error", "error", "ok");
                    throw;
                }

            }
            // Local function is declared but never used disabled above used in xaml
            [RelayCommand]
            async Task RemoveFromCartAsync()
            {
                _logger.LogDebug($"Here");

                try
                {

                }
                catch (Exception)
                {
                    await Shell.Current.DisplayAlert("error", "error", "ok");
                    throw;
                }

            }
        }
    }
}
