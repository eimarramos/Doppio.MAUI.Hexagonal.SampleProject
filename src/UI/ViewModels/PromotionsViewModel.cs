using System.Collections.ObjectModel;
using ApplicationLayer.Services.PromotionService;
using CommunityToolkit.Mvvm.ComponentModel;
using Domain.Models;
using UI.ViewModels.SharedViewModels;

namespace UI.ViewModels
{
    public partial class PromotionsViewModel : BaseViewModel
    {
        private readonly PromotionService _promotionsService;

        [ObservableProperty]
        private ObservableCollection<Promotion> _promotions = new ObservableCollection<Promotion>();

        public PromotionsViewModel(PromotionService promotionService)
        {
            Title = "Promotions";

            _promotionsService = promotionService;

            LoadDataAsync();
        }

        public async void LoadDataAsync()
        {
            try
            {
                IsBusy = true;

                Promotions = await GetPromotionsAsync();
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

        private async Task<ObservableCollection<Promotion>> GetPromotionsAsync()
        {
            var shops = await _promotionsService.GetAll();

            return new ObservableCollection<Promotion>(shops);
        }
    }
}
