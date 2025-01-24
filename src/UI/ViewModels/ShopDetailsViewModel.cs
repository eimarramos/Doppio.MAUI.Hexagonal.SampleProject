using ApplicationLayer.Services.CoffeeService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using System.Collections.ObjectModel;
using UI.ViewModels.Interfaces;
using UI.ViewModels.SharedViewModels;

namespace UI.ViewModels
{
    public partial class ShopDetailsViewModel : BaseViewModel, ICheckOutViewModel, IQueryAttributable
    {
        private readonly CoffeeService _coffeeService;

        [ObservableProperty]
        private Shop _shop = new Shop();

        [ObservableProperty]
        private ObservableCollection<Coffee> _coffees = new ObservableCollection<Coffee>();

        [ObservableProperty]
        private int _itemsCount = 0;

        [ObservableProperty]
        private double _currentTotal = 0;

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
        private async Task GoToMenu()
        {
            try
            {
                IsBusy = true;

                var parameters = new ShellNavigationQueryParameters
                {
                    { "ShopId", Shop.Id }
                };

                await Shell.Current.GoToAsync("menu", parameters);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
