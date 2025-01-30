using System.Collections.ObjectModel;
using ApplicationLayer.Services.CartService;
using CommunityToolkit.Mvvm.ComponentModel;
using Domain.Models;
using UI.ViewModels.SharedViewModels;

namespace UI.ViewModels
{
    public partial class CartViewModel : BaseViewModel
    {
        private readonly CartService _cartService;

        [ObservableProperty]
        private ObservableCollection<CartDetail> _cartDetails = [];

        public CartViewModel(CartService cartService)
        {
            Title = "Cart";
            _cartService = cartService;

            LoadDataAsync();
        }

        public async void LoadDataAsync()
        {
            try
            {
                IsBusy = true;

                await GetCartDetails();
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

        private async Task GetCartDetails()
        {
            var cartDetails = await _cartService.GetCartDetails();
            CartDetails = new ObservableCollection<CartDetail>(cartDetails);
        }
    }
}
