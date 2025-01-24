using ApplicationLayer.Services.CoffeeService;
using CommunityToolkit.Mvvm.ComponentModel;
using Domain.Models;
using System.Collections.ObjectModel;
using UI.ViewModels.Interfaces;
using UI.ViewModels.SharedViewModels;

namespace UI.ViewModels
{
    public partial class MenuViewModel : BaseViewModel, ICheckOutViewModel, IQueryAttributable
    {
        private readonly CoffeeService _coffeeService;

        private int _shopId;

        [ObservableProperty]
        private ObservableCollection<Coffee> _coffees = new ObservableCollection<Coffee>();

        [ObservableProperty]
        private int _itemsCount = 0;

        [ObservableProperty]
        private double _currentTotal = 0;

        public MenuViewModel(CoffeeService coffeeService)
        {
            Title = "Menu";
            _coffeeService = coffeeService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("ShopId", out var shopObj) && shopObj is int shopId)
            {
                _shopId = shopId;
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
            List<Coffee> coffees = await _coffeeService.GetAllByShopId(_shopId);

            if (coffees == null) return;

            Coffees = new ObservableCollection<Coffee>(coffees);
        }
    }
}
