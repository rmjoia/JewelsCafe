using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Services;
using JewelsCafe.ViewModels;
using JewelsCafe.Views;
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
            })
            .RegisterViews()
            .RegisterViewModels()
            .RegisterServices()
            .RegisterRepositories();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
    public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddScoped<MainPage>();
        builder.Services.AddScoped<SoftDrinksPage>();
        builder.Services.AddScoped<SnacksPage>();
        builder.Services.AddScoped<AdminPage>();
        builder.Services.AddScoped<CheckoutPage>();

        return builder;
    }

    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddScoped<CoffeeListViewModel>();
        builder.Services.AddScoped<SoftDrinksViewModel>();
        builder.Services.AddScoped<SnacksViewModel>();
        builder.Services.AddScoped<AdminViewModel>();
        builder.Services.AddScoped<CheckoutViewModel>();

        return builder;
    }

    private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddScoped<MenuService>();
        builder.Services.AddScoped<OrderService>();
        builder.Services.AddScoped<CheckoutService>();
        builder.Services.AddScoped<FileService>();

        return builder;
    }

    private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<GenericRepository<Beverage>>();
        builder.Services.AddSingleton<GenericRepository<Food>>();
        builder.Services.AddSingleton<GenericRepository<IFood>>();
        builder.Services.AddSingleton<CheckoutRepository>();

        return builder;
    }
}

