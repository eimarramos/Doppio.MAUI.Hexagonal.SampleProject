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
            await Task.Run(async () =>
            {
                try
                {
                    IsBusy = true;

                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }
    }
}
