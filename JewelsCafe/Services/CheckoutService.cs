using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Views;
using Microsoft.Extensions.Logging;
using System;

namespace JewelsCafe.Services
{
    public class CheckoutService
    {
        private readonly ILogger<CheckoutService> _logger;
        private readonly GenericRepository<IFood> _orderRepository;
        private readonly OrderService _orderService;
        private readonly CheckoutRepository _checkoutRepository;
        private IEnumerable<CartItem> shoppingCart;

        public CheckoutService(
            ILogger<CheckoutService> logger,
            GenericRepository<IFood> orderRepository,
            OrderService orderService,
            CheckoutRepository checkoutRepository
            )
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _orderService = orderService;
            _checkoutRepository = checkoutRepository;
        }

        internal IEnumerable<CartItem> Update()
        {
            shoppingCart = _orderRepository
                        .GetAll()
                        .ToList()
                        .Select(item => new CartItem { Name = item.Name, Discount = item.Discount, Price = item.Price, Vat = item.Vat });

            return shoppingCart;
        }

        internal IEnumerable<CartItem> GetCart()
        {
            return shoppingCart;
        }

        internal async Task CheckoutAsync(Order order)
        {
            var checkoutResult = await _orderService.PlaceOrderAsync(order);

            if (checkoutResult)
            {
                _checkoutRepository.Add(new Checkout
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Order = order
                });

                _orderService.Clear();

                await Shell.Current.GoToAsync(nameof(MainPage), true);
            }
        }
    }
}