using JewelsCafe.Models;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace JewelsCafe.ViewModels
{
    public partial class SnacksViewModel : ViewModelBase
    {
        public SnacksViewModel(ILogger<AdminViewModel> logger, OrderService orderService, CheckoutService checkoutService) : base(logger, checkoutService, orderService)
        {
            Title = "Take some time... Have a snack...";
            UpdateCart();
        }
        
        public ObservableCollection<Food> SnacksList { get; private set; }
    }
}
