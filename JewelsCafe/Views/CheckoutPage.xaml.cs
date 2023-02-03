using JewelsCafe.ViewModels;

namespace JewelsCafe.Views;

public partial class CheckoutPage : ContentPage
{
    private readonly CheckoutViewModel _checkoutViewModel;

    public CheckoutPage(CheckoutViewModel checkoutViewModel)
	{
		InitializeComponent();
		BindingContext = checkoutViewModel;
        _checkoutViewModel = checkoutViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        _checkoutViewModel.UpdateCheckoutList();
    }
}