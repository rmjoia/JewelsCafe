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

        [ObservableProperty]
        private string customerName;

        [ObservableProperty]
        private string customerPhoneNumber;

        public CheckoutViewModel(
            ILogger<CheckoutViewModel> logger,
            CheckoutService checkoutService,
            OrderService orderService
            ) : base(logger, checkoutService, orderService)
        {
            Title = "Checkout";

            _logger = logger;
            _checkoutService = checkoutService;
            _orderService = orderService;

            UpdateCart();
            _orderService.OrderChanged += orderService_OrderChanged;
        }

        public ObservableCollection<OrderItem> OrderList { get; set; } = new();



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

        [RelayCommand]
        async Task PlaceOrder()
        {
            if (string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(CustomerPhoneNumber))
            {
                await Shell.Current.DisplayAlert("Warning", "Please enter your name and email address.", "OK");
                return;
            }

            var order = new Order
            {
                CustomerName = CustomerName,
                CustomerPhoneNumber = CustomerPhoneNumber,
                OrderItems = _orderService.GetAll().Select(food => new OrderItem { Food = food }).ToList()
            };

            await _checkoutService.CheckoutAsync(order);
            CustomerName = "";
            CustomerPhoneNumber = "";
            UpdateCart();
            UpdateCheckoutList();
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