using System.Collections.ObjectModel;
using ApplicationLayer.Services.CartService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using UI.Services;
using UI.ViewModels.SharedViewModels;

namespace UI.ViewModels
{
    public partial class CartViewModel : BaseViewModel
    {
        private readonly CartService _cartService;
        private readonly CartActionsService _cartActionsService;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CartHasItems))]
        private ObservableCollection<CartDetail> _cartDetails = [];

        public bool CartHasItems => CartDetails.Count > 0;

        [ObservableProperty]
        private decimal _currentTotal = 0;

        public CartViewModel(CartService cartService, CartActionsService cartActionsService)
        {
            Title = "Cart";
            _cartService = cartService;
            _cartActionsService = cartActionsService;

            _cartActionsService.CartUpdated += OnCartUpdated;

            LoadDataAsync();
        }

        private void OnCartUpdated()
        {
            LoadDataAsync();
        }

        public async void LoadDataAsync()
        {
            try
            {
                IsBusy = true;
                await Task.WhenAll(
                    GetCartDetailsAsync(),
                    GetTotalAsync()
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

        private async Task GetCartDetailsAsync()
        {
            var cartDetails = await _cartService.GetCartDetails();
            CartDetails = new ObservableCollection<CartDetail>(cartDetails);
        }

        private async Task GetTotalAsync()
        {
            CurrentTotal = await _cartService.GetTotal(); ;
        }

        [RelayCommand]
        private async Task AddCoffeeToCart(int coffeId)
        {
            try
            {
                IsBusy = true;

                await _cartService.AddCoffeeToCart(coffeId);

                _cartActionsService.UpdateCart();
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
        private async Task RemoveCoffeeFromCart(int coffeId)
        {
            try
            {
                IsBusy = true;

                await _cartService.RemoveCoffeeFromCart(coffeId);

                _cartActionsService.UpdateCart();
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
    }
}
