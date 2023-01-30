using JewelsCafe.ViewModels;

namespace JewelsCafe.Views;

public partial class SoftDrinksPage : ContentPage
{
	public SoftDrinksPage(SoftDrinksViewModel softDrinksViewModel)
	{
		InitializeComponent();
		BindingContext = softDrinksViewModel;
    }
}