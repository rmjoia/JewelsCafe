using CommunityToolkit.Mvvm.ComponentModel;
using JewelsCafe.Models;
using JewelsCafe.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace JewelsCafe.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsDoneLoading))]
        private bool isLoading;

        public bool IsDoneLoading => !IsLoading;

        [ObservableProperty]
        ObservableCollection<IFood> cart = new ();

        [ObservableProperty]
        protected int cartCount = 0;

        [ObservableProperty]
        protected decimal totalAmount = 0.0m;
    }
}
