using System.Collections.ObjectModel;
using ApplicationLayer.Services.CartService;
using ApplicationLayer.Services.CoffeeService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using UI.Services;
using UI.ViewModels.SharedViewModels;

namespace UI.ViewModels
{
    public partial class ShopDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly CoffeeService _coffeeService;
        private readonly CartService _cartService;
        private readonly CartActionsService _cartActionsService;

        [ObservableProperty]
        private Shop _shop = new Shop();

        [ObservableProperty]
        private ObservableCollection<Coffee> _topThreeCoffees = new ObservableCollection<Coffee>();

        [ObservableProperty]
        private ObservableCollection<Coffee> _allCoffees = new ObservableCollection<Coffee>();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CartHasItems))]
        private int _itemsCount = 0;

        public bool CartHasItems => ItemsCount > 0;

        [ObservableProperty]
        private decimal _currentTotal = 0;

        public ShopDetailsViewModel(CoffeeService coffeeService, CartService cartService, CartActionsService cartActionsService)
        {
            Title = "Menu";
            _coffeeService = coffeeService;
            _cartService = cartService;

            _cartActionsService = cartActionsService;

            _cartActionsService.CartUpdated += OnCartUpdated;
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
                await Task.WhenAll(
                    GetTopThreeCoffeesAsync(),
                    GetCartSummaryAsync()
                );
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

                _cartActionsService.UpdateCart();
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

        private async Task GetCartSummaryAsync()
        {
            var getTotalTask = _cartService.GetTotal();
            var getItemsCountTask = _cartService.GetCurrentItemsCount();

            await Task.WhenAll(getTotalTask, getItemsCountTask);

            CurrentTotal = await getTotalTask;
            ItemsCount = await getItemsCountTask;
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


        [RelayCommand]
        private async Task GoToCart()
        {
            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync("///cart");
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

        private void OnCartUpdated()
        {
            UpdateCheckOutView();
        }

        private async void UpdateCheckOutView()
        {
            await GetCartSummaryAsync();
        }
    }
}
