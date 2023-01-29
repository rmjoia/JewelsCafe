using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Services;
using JewelsCafe.ViewModels;
using Microsoft.Extensions.Logging;

namespace JewelsCafe;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        // Dependency Injection

        //	Views
        builder.Services.AddScoped<MainPage>();

		//	ViewModels
		builder.Services.AddScoped<CoffeeListViewModel>();
		
		//	Repositories
		builder.Services.AddSingleton<GenericRepository<Beverage>>();
        builder.Services.AddSingleton<GenericRepository<Food>>();
        builder.Services.AddSingleton<GenericRepository<IFood>>();

        //	Services
        builder.Services.AddScoped<MenuService>();
        builder.Services.AddScoped<OrderService>();
        builder.Services.AddScoped<CheckoutService>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

