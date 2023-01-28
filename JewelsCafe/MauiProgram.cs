using JewelsCafe.Models;
using JewelsCafe.Repositories;
using JewelsCafe.Services;
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
		builder.Services.AddSingleton<GenericRepository<Beverege>>();
        builder.Services.AddSingleton<GenericRepository<Food>>();
        builder.Services.AddTransient<MenuService>();
		

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

