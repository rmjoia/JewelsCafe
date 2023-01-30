using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;

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
            CheckoutService checkoutService) : base(checkoutService)
        {
            Title = "Refresh yourself...";
            _logger = logger;
            _softDrinksRepository = beverageRepository;
            _orderService = orderService;
            
            UpdateCart();
        }
    }
}
