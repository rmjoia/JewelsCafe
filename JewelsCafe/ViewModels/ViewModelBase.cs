using CommunityToolkit.Mvvm.ComponentModel;

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
        
    }
}
