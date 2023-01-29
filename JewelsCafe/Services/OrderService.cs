
using CommunityToolkit.Mvvm.ComponentModel;
using JewelsCafe.Models;
using JewelsCafe.Repositories;
using Microsoft.Extensions.Logging;

namespace JewelsCafe.Services
{
    public class OrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly GenericRepository<IFood> _orderRepository;
        private readonly GenericRepository<Beverage> _beverageRepository;
        private readonly GenericRepository<Food> _foodRepository;
        private readonly string error = "An exception ocurred while {0}: {1}";

        public OrderService(
            ILogger<OrderService> logger, 
            GenericRepository<IFood> orderRepository, 
            GenericRepository<Beverage> beverageRepository,
            GenericRepository<Food> foodRepository
            )
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _beverageRepository = beverageRepository;
            _foodRepository = foodRepository;

        }
        
        public bool AddToOrder(Guid foodId)
        {
            bool operation = false;
            try
            {
                var food = GetFoodItem(foodId);

                // Has to be implemented as as stack, so we don't remove all items with the same id and we keep the order
                _orderRepository.Add(food);

                operation = food != null;
            }
            catch (Exception ex)
            {
                _logger.LogError(error, nameof(AddToOrder), ex.Message);
            }

            return operation;
        }

        public bool RemoveFromOrder(Guid foodId)
        {
            bool operation = false;
            try
            {
                // Has to be implemented as as stack, so we don't remove all items with the same id and we keep the order
                _orderRepository.Delete(foodId);

                operation = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(error, nameof(AddToOrder), ex.Message);
            }

            return operation;
        }

        private IFood GetFoodItem(Guid foodId)
        {
            IFood food = _beverageRepository.GetById(foodId);

            food ??= _foodRepository.GetById(foodId);

            return food;
        }
    }
}
