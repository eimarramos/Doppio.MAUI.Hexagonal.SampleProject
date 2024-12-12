using ApplicationLayer.Services.CategoryService;
using ApplicationLayer.Services.ShopService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using System.Collections.ObjectModel;

namespace UI.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly CategoryService _categoryService;
        private readonly ShopService _shopService;

        private ObservableCollection<Shop> _initialShops = new ObservableCollection<Shop>();

        [ObservableProperty]
        private ObservableCollection<Category> categories = new ObservableCollection<Category>();

        [ObservableProperty]
        private ObservableCollection<Shop> shops = new ObservableCollection<Shop>();

        [ObservableProperty]
        private Category? selectedCategory;

        private Category? _previousCategory;

        [ObservableProperty]
        private string filterText = string.Empty;

        public HomeViewModel(CategoryService categoryService, ShopService shopService)
        {
            _categoryService = categoryService;
            _shopService = shopService;

            Title = "Home";

            LoadDataAsync();
        }

        [RelayCommand]
        private void ChangeCategorySelection(Category tappedCategory)
        {
            SelectedCategory = tappedCategory;

            if (SelectedCategory == _previousCategory)
            {
                ClearCategorySelection();
                return;
            }

            _previousCategory = SelectedCategory;
        }

        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryService.GetAll();

            if (categories == null) return;

            Categories = new ObservableCollection<Category>(categories);
        }

        private async Task GetShopsAsync()
        {
            var shops = await _shopService.GetAll();

            if (shops == null) return;

            Shops = new ObservableCollection<Shop>(shops);
        }

        public async void LoadDataAsync()
        {
            try
            {
                IsBusy = true;

                await Task.WhenAll(GetCategoriesAsync(), GetShopsAsync());

                _initialShops = new ObservableCollection<Shop>(Shops);
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

        partial void OnFilterTextChanged(string value)
        {
            FilterShops();
        }

        partial void OnSelectedCategoryChanged(Category? value)
        {
            FilterShops();
        }

        private void FilterShops()
        {
            var filteredShops = _initialShops
                .Where(s =>
                    (SelectedCategory == null || s.CategoriesString.Contains(SelectedCategory.Name))
                    && s.Name.ToLower().Contains(FilterText.ToLower()))
                .ToList();

            Shops = new ObservableCollection<Shop>(filteredShops);
        }

        private void ClearCategorySelection()
        {
            SelectedCategory = null;
            _previousCategory = null;
        }
    }
}
