using CommunityToolkit.Mvvm.ComponentModel;

namespace UI.ViewModels.SharedViewModels
{
    public abstract partial class CheckOutViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _itemsCount = 10;

        [ObservableProperty]
        private double _currentTotal = 100;
    }
}
