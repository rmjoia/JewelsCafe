using JewelsCafe.Services;

namespace JewelsCafe.ViewModels
{
    public partial class SnacksViewModel : ViewModelBase
    {
        public SnacksViewModel(CheckoutService checkoutService) : base(checkoutService)
        {
            Title = "Take some time... Have a snack...";
            UpdateCart();
        }
    }
}
