using UI.ViewModels;

namespace UI.Views.Menu;

public partial class MenuPage : ContentPage
{
	public MenuPage(ShopDetailsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}