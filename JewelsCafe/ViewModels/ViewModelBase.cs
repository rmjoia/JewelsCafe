using CommunityToolkit.Mvvm.ComponentModel;
using JewelsCafe.Models;
using JewelsCafe.Services;
using System.Collections.ObjectModel;

namespace JewelsCafe.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        private readonly CheckoutService _checkoutService;
        
        public ViewModelBase(CheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
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
