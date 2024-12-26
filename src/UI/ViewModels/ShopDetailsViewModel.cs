using ApplicationLayer.Services.CoffeeService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using System.Collections.ObjectModel;

namespace UI.ViewModels
{
    public partial class ShopDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly CoffeeService _coffeeService;

        [ObservableProperty]
        private Shop shop = new Shop();
        [ObservableProperty]
        private ObservableCollection<Coffee> coffees = new ObservableCollection<Coffee>();

        public ShopDetailsViewModel(CoffeeService coffeeService)
        {
            _coffeeService = coffeeService;       
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Shop", out var shopObj) && shopObj is Shop shop)
            {
                Shop = shop;
                LoadDataAsync();
            }
        }

        public async void LoadDataAsync()
        {
            try
            {
                IsBusy = true;

                await GetCoffeesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GetCoffeesAsync()
        {
            List<Coffee> coffees = await _coffeeService.GetTopThreeByShopId(Shop.Id);

            if (coffees == null) return;

            Coffees = new ObservableCollection<Coffee>(coffees);
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
