using JewelsCafe.ViewModels;

namespace JewelsCafe;

public partial class MainPage : ContentPage
{
    public MainPage(CoffeeListViewModel coffeeListViewModel)
    {
        InitializeComponent();
        BindingContext = coffeeListViewModel;
    }
}


