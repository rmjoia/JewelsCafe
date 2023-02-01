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
            GetSoftDrinksList();
        }

        public ObservableCollection<Beverage> SoftDrinksList { get; private set; }

        void GetSoftDrinksList()
        {
            if (IsLoading)
            {
                return;
            }
            try
            {
                SoftDrinksList = new();
                IsLoading = true;
                _softDrinksRepository
                    .GetAll()
                    .Where(beverage => beverage.Family == FoodFamily.Soda || beverage.Family == FoodFamily.Juice)
                    .ToList()
                    .ForEach(softDrink => SoftDrinksList.Add((softDrink as Beverage)));
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
