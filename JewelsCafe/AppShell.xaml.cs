using JewelsCafe.Views;

namespace JewelsCafe;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}

