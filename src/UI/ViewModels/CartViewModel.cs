using System.Collections.ObjectModel;
using ApplicationLayer.Services.CartService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        }

        [RelayCommand]
        private async Task GetCartDetails()
        {
            try
            {
                IsBusy = true;

                var cartDetails = await _cartService.GetCartDetails();
                CartDetails = new ObservableCollection<CartDetail>(cartDetails);
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
        private void Disappearing()
        {

        }
    }
}
