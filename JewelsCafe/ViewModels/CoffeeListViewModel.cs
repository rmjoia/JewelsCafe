using CommunityToolkit.Mvvm.Input;
using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace JewelsCafe.ViewModels
{
    [QueryProperty(nameof(Food.Id), "Id")]
    public partial class CoffeeListViewModel : ViewModelBase
    {
        private readonly GenericRepository<Beverage> _coffeeRepository;
        private readonly OrderService _orderService;
        private readonly ILogger<CoffeeListViewModel> _logger;

        public CoffeeListViewModel(ILogger<CoffeeListViewModel> logger, 
            GenericRepository<Beverage> genericRepository, 
            OrderService orderService,
            CheckoutService checkoutService
            ) : base(checkoutService)
        {
            Title = "Try our Selected Blends...";
            _logger = logger;
            _coffeeRepository = genericRepository;
            _orderService = orderService;

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
                Family = FoodFamily.Soda,
                Price = 2.50M,
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
            Family = FoodFamily.Coffee,
            Price = 2.50M
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
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private async Task AddToCartAsync(Guid foodId)
        {
            try
            {
                _orderService.AddToOrder(foodId);
                UpdateCart();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error while adding to order", ex.Message);
                await Shell.Current.DisplayAlert("Error", "An error has occurred while adding your order!", "Ok");
            }
        }

        [RelayCommand]
        private async Task RemoveFromCartAsync(Guid foodId)
        {
            try
            {
                _orderService.RemoveFromOrder(foodId);
                UpdateCart();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while updating your order", ex.Message);
                await Shell.Current.DisplayAlert("Error", "An error has occurred while updating your order!", "Ok");
            }
        }
    }
}
