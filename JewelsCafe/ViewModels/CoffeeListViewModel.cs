using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace JewelsCafe.ViewModels
{
    public partial class CoffeeListViewModel : ViewModelBase
    {
        private readonly ILogger<CoffeeListViewModel> _logger;
        private readonly GenericRepository<Beverage> _coffeeRepository;
        private readonly OrderService _orderService;
        
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
            _orderService = orderService;

            _orderService.OrderChanged += orderService_OrderChanged;

            UpdateCart();
            GetCoffeeList();
        }

        private void orderService_OrderChanged(object sender, EventArgs e)
        {
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

        ~CoffeeListViewModel()
        {
            if (orderService_OrderChanged != null)
            {
                _orderService.OrderChanged -= orderService_OrderChanged;
            }
        }
    }
}
