using JewelsCafe.Models;
using JewelsCafe.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace JewelsCafe.Services
{
    public class CheckoutService
    {
        private readonly ILogger<CheckoutService> _logger;
        private readonly GenericRepository<IFood> _orderRepository;

        public CheckoutService(ILogger<CheckoutService> logger, GenericRepository<IFood> orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        internal IEnumerable<CartItem> Update()
        {
            var result = _orderRepository
                        .GetAll()
                        .ToList()
                        .Select(item => new CartItem { Name = item.Name, Discount = item.Discount, Price = item.Price, Vat = item.Vat });

            return result;
        }
    }
}
