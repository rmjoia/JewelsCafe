using JewelsCafe.ViewModels;

namespace JewelsCafe.Views;

public partial class AdminPage : ContentPage
{
	public AdminPage(AdminViewModel adminViewModel)
	{
		InitializeComponent();
        BindingContext = adminViewModel;
    }
}