using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JewelsCafe.ViewModels
{
    public partial class SnacksViewModel : ViewModelBase
    {
        private readonly ILogger<SnacksViewModel> _logger;
        private readonly GenericRepository<Food> _snacksRepository;
        private readonly OrderService _orderService;

        public SnacksViewModel(
            ILogger<SnacksViewModel> logger,
            OrderService orderService,
            CheckoutService checkoutService,
            GenericRepository<Food> snacksRepository
            ) : base(logger, checkoutService, orderService)
        {
            Title = "Take some time... Have a snack...";
            _logger = logger;
            _snacksRepository = snacksRepository;

            _orderService = orderService;

            _orderService.OrderChanged += orderService_OrderChanged;

            UpdateCart();
            GetSnacksList();
        }

        private void orderService_OrderChanged(object sender, EventArgs e)
        {
            UpdateCart();
            GetSnacksList();
        }

        public ObservableCollection<Food> SnacksList { get; private set; }

        void GetSnacksList()
        {
            if (IsLoading)
            {
                return;
            }
            try
            {


                SnacksList = new();
                IsLoading = true;
                _snacksRepository
                    .GetAll()
                    .Where(snack => snack.Family == FoodFamily.Chocolate)
                    .ToList()
                    .ForEach(snack => SnacksList.Add(snack as Food));
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

        ~SnacksViewModel()
        {
            if (orderService_OrderChanged != null)
            {
                _orderService.OrderChanged -= orderService_OrderChanged;
            }
        }
    }
}
