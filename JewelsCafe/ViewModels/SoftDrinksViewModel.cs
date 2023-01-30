﻿using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;

namespace JewelsCafe.ViewModels
{
    public class SoftDrinksViewModel : ViewModelBase
    {
        private readonly ILogger<SoftDrinksViewModel> _logger;
        private readonly GenericRepository<Beverage> _softDrinksRepository;
        private readonly OrderService _orderService;
        private readonly CheckoutService _checkoutService;

        public SoftDrinksViewModel(ILogger<SoftDrinksViewModel> logger,
            GenericRepository<Beverage> beverageRepository,
            OrderService orderService,
            CheckoutService checkoutService)
        {
            Title = "Refresh yourself...";
            _logger = logger;
            _softDrinksRepository = beverageRepository;
            _orderService = orderService;
            _checkoutService = checkoutService;
        }

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
