using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JewelsCafe.Models;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Linq;

namespace JewelsCafe.ViewModels
{
    public partial class CheckoutViewModel : ViewModelBase
    {
        private ILogger<CheckoutViewModel> _logger;
        private CheckoutService _checkoutService;
        private OrderService _orderService;

        public CheckoutViewModel(
            ILogger<CheckoutViewModel> logger,
            CheckoutService checkoutService,
            OrderService orderService) : base(logger, checkoutService, orderService)
        {
            Title = "Checkout";

            _logger = logger;
            _checkoutService = checkoutService;
            _orderService = orderService;

            UpdateCart();
            _orderService.OrderChanged += orderService_OrderChanged;
        }

        public ObservableCollection<OrderItem> OrderList { get; set; } = new();

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        private void orderService_OrderChanged(object sender, EventArgs e)
        {
            UpdateCart();
            UpdateCheckoutList();
        }

        public void UpdateCheckoutList()
        {
            OrderList.Clear();

            var distinctOrders = _orderService.GetAll().Distinct().ToList();

            distinctOrders.ForEach(order => OrderList.Add(new OrderItem
            {
                Food = order,
                Price = order.Price,
                Quantity = _orderService.GetAll().Where(food => food.Name == order.Name).Count()
            }));
        }

        ~CheckoutViewModel()
        {
            if (orderService_OrderChanged != null)
            {
                _orderService.OrderChanged -= orderService_OrderChanged;
            }
        }
    }
}
