using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JewelsCafe.Models;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace JewelsCafe.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        private readonly ILogger<ViewModelBase> _logger;
        private readonly CheckoutService _checkoutService;
        private readonly OrderService _orderService;

        public ViewModelBase(ILogger<ViewModelBase> logger, CheckoutService checkoutService, OrderService orderService)
        {
            _logger = logger;
            _checkoutService = checkoutService;
            _orderService = orderService;
        }

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsDoneLoading))]
        private bool isLoading;

        public bool IsDoneLoading => !IsLoading;

        [ObservableProperty]
        ObservableCollection<IFood> cart = new ();

        [ObservableProperty]
        protected int cartCount = 0;

        [ObservableProperty]
        protected decimal totalAmount = 0.0m;

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

        protected void UpdateCart()
        {
            IsLoading = true;

            try
            {
                var result = _checkoutService.Update();

                CartCount = result.ToList().Count();
                TotalAmount = result.Sum(items => items.Price);
            }
            catch (Exception)
            {

            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
