using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;

namespace UI.ViewModels
{
    [QueryProperty(nameof(Shop), "Shop")]
    public partial class ShopDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Shop? shop;
        public ShopDetailsViewModel()
        { }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
