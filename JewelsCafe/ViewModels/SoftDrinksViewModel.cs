using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace JewelsCafe.ViewModels
{
    public class SoftDrinksViewModel : ViewModelBase
    {
        private readonly ILogger<SoftDrinksViewModel> _logger;
        private readonly GenericRepository<Beverage> _softDrinksRepository;
        private readonly OrderService _orderService;

        public SoftDrinksViewModel(ILogger<SoftDrinksViewModel> logger,
            GenericRepository<Beverage> beverageRepository,
            OrderService orderService,
            CheckoutService checkoutService) : base(logger, checkoutService, orderService)
        {
            Title = "Refresh yourself...";
            _logger = logger;
            _softDrinksRepository = beverageRepository;
            _orderService = orderService;
            
            UpdateCart();
        }

        public ObservableCollection<Food> SoftDrinksList { get; private set; }
    }
}
