using JewelsCafe.ViewModels;

namespace JewelsCafe.Views;

public partial class MainPage : ContentPage
{
    public MainPage(CoffeeListViewModel coffeeListViewModel)
    {
        InitializeComponent();
        BindingContext = coffeeListViewModel;
    }
}


