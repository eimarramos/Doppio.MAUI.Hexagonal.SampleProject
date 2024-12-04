using ApplicationLayer.Services.CategoryService;
using CommunityToolkit.Mvvm.ComponentModel;
using Domain.Models;
using System.Collections.ObjectModel;

namespace UI.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly CategoryService _categoryService;

        [ObservableProperty]
        public ObservableCollection<Category> categories;

        public HomeViewModel(CategoryService categoryService)
        {
            _categoryService = categoryService;

            Categories = new ObservableCollection<Category>();
            Title = "Home";

            LoadDataAsync();
        }

        private async Task GetCategoriesAsync()
        {
            try
            {
                IsBusy = true;
                var categories = await _categoryService.GetAll();

                if (categories == null) return;

                Categories = new ObservableCollection<Category>(categories);
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

        private async void LoadDataAsync()
        {
            await GetCategoriesAsync();
        }
    }
}
