using JewelsCafe.ViewModels;

namespace JewelsCafe.Views;

public partial class SnacksPage : ContentPage
{
	public SnacksPage(SnacksViewModel snacksViewModel)
	{
		InitializeComponent();
		BindingContext = snacksViewModel;
    }
}