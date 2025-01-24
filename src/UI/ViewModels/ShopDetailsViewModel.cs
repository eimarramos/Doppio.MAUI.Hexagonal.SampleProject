using System.Collections.ObjectModel;
using ApplicationLayer.Services.CartService;
using ApplicationLayer.Services.CoffeeService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using UI.ViewModels.SharedViewModels;

namespace UI.ViewModels
{
    public partial class ShopDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly CoffeeService _coffeeService;
        private readonly CartService _cartService;

        [ObservableProperty]
        private Shop _shop = new Shop();

        [ObservableProperty]
        private ObservableCollection<Coffee> _topThreeCoffees = new ObservableCollection<Coffee>();

        [ObservableProperty]
        private ObservableCollection<Coffee> _allCoffees = new ObservableCollection<Coffee>();

        [ObservableProperty]
        private int _itemsCount = 10;

        [ObservableProperty]
        private decimal _currentTotal = 120;

        public ShopDetailsViewModel(CoffeeService coffeeService, CartService cartService)
        {
            Title = "Menu";
            _coffeeService = coffeeService;
            _cartService = cartService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Shop", out var shopObj) && shopObj is Shop shop)
            {
                Shop = shop;
                LoadDataAsync();
            }
        }

        [RelayCommand]
        private async Task GoToMenu()
        {
            try
            {
                IsBusy = true;

                await Task.WhenAll(
                    Shell.Current.GoToAsync("menu"),
                    GetAllCoffeesAsync()
                );
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

        [RelayCommand]
        private async Task AddToCart(int coffeeId)
        {
            try
            {
                IsBusy = true;

                await _cartService.AddCoffeeToCart(coffeeId);

                await UpdateCartSummaryAsync();
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

        public async Task UpdateCartSummaryAsync()
        {
            var getTotalTask = _cartService.GetTotal();
            var getItemsCountTask = _cartService.GetCurrentItemsCount();

            await Task.WhenAll(getTotalTask, getItemsCountTask);

            CurrentTotal = await getTotalTask;
            ItemsCount = await getItemsCountTask;
        }

        public async void LoadDataAsync()
        {
            try
            {
                IsBusy = true;

                await GetTopThreeCoffeesAsync();
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

        private async Task GetTopThreeCoffeesAsync()
        {
            List<Coffee> coffees = await _coffeeService.GetTopThreeByShopId(Shop.Id);

            if (coffees == null) return;

            TopThreeCoffees = new ObservableCollection<Coffee>(coffees);
        }

        private async Task GetAllCoffeesAsync()
        {
            List<Coffee> coffees = await _coffeeService.GetAllByShopId(Shop.Id);

            if (coffees == null) return;

            AllCoffees = new ObservableCollection<Coffee>(coffees);
        }
    }
}
