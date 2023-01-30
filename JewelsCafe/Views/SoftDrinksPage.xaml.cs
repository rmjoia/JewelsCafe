using JewelsCafe.ViewModels;

namespace JewelsCafe.Views;

public partial class SoftDrinksPage : ContentPage
{
	public SoftDrinksPage()
	{
		InitializeComponent();
        BindingContext = new SoftDrinksViewModel();
    }
}