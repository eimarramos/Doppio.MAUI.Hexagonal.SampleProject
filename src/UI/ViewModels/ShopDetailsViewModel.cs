using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;

namespace UI.ViewModels
{
    public partial class ShopDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private Shop? shop;
        public ShopDetailsViewModel()
        {}

        [RelayCommand]
        private async Task GoHome()
        {
            await Task.Run(async () =>
            {
                try
                {
                    IsBusy = true;

                    await Shell.Current.GoToAsync("///home");
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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Shop = query["Shop"] as Shop;
        }
    }
}
