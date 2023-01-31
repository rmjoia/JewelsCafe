using JewelsCafe.Services;
using Microsoft.Extensions.Logging;

namespace JewelsCafe.ViewModels
{
    public partial class AdminViewModel : ViewModelBase
    {
        public AdminViewModel(ILogger<AdminViewModel> logger, OrderService orderService, CheckoutService checkoutService) : base(logger, checkoutService, orderService)
        {
            Title = "Management & Credits";
        }
    }
}
