using CommunityToolkit.Mvvm.ComponentModel;
using JewelsCafe.Models;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace JewelsCafe.ViewModels
{
    public partial class AdminViewModel : ViewModelBase
    {
        private readonly CheckoutService _checkoutService;

        [ObservableProperty]
        private ObservableCollection<Checkout> daySalesList;

        public AdminViewModel(ILogger<AdminViewModel> logger, OrderService orderService, CheckoutService checkoutService) : base(logger, checkoutService, orderService)
        {
            Title = "Management & Credits";

            _checkoutService = checkoutService;

            GetSalesList();

            _checkoutService.Checkout += checkoutService_Checkout;
        }

        private void checkoutService_Checkout(object sender, EventArgs e)
        {
            GetSalesList();
        }

        private void GetSalesList()
        {
            DaySalesList = new();
            
            if (IsLoading)
            {
                return;
            }
            try
            {
                IsLoading = true;
                
                _checkoutService
              .GetAll()
              .ToList()
              .ForEach(sales => DaySalesList.Add(new Checkout
              {
                  Id = sales.Id,
                  Date = sales.Date,
                  Order = sales.Order
              }));
            }
            finally
            {
                IsLoading = false;
            }
        }

        ~AdminViewModel()
        {
            if (checkoutService_Checkout != null)
            {
                _checkoutService.Checkout -= checkoutService_Checkout;
            }
        }
    }
}
