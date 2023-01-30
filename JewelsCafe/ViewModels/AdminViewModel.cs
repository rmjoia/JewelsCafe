using JewelsCafe.Services;

namespace JewelsCafe.ViewModels
{
    public partial class AdminViewModel : ViewModelBase
    {
        public AdminViewModel(CheckoutService checkoutService) : base(checkoutService)
        {
            Title = "Management & Credits";
        }
    }
}
