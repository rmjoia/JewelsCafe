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
        private readonly ILogger<CoffeeListViewModel> _logger;

        public ObservableCollection<Beverage> ItemsInOrder;
       
        public CoffeeListViewModel(ILogger<CoffeeListViewModel> logger, 
            GenericRepository<Beverage> genericRepository, 
            OrderService orderService,
            CheckoutService checkoutService
            ) : base(logger, checkoutService, orderService)
        {
            Title = "Try our Selected Blends...";
            _logger = logger;
            _coffeeRepository = genericRepository;

            UpdateCart();
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
    }
}
