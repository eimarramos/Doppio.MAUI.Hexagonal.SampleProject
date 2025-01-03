using ApplicationLayer.Services.CoffeeService;
using CommunityToolkit.Mvvm.ComponentModel;
using Domain.Models;
using System.Collections.ObjectModel;

namespace UI.ViewModels
{
    public partial class MenuViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly CoffeeService _coffeeService;
        private int _shopId;
        [ObservableProperty]
        private ObservableCollection<Coffee> coffees = new ObservableCollection<Coffee>();
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
