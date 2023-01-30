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

            GetCoffeeList();
        }

        public ObservableCollection<Beverage> CoffeeList { get; private set; }

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
                    .Where(beverage => beverage.Family == FoodFamily.Coffee || beverage.Family == FoodFamily.Tea)
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
