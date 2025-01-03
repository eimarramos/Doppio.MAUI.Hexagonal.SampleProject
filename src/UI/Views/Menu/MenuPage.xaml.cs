using UI.ViewModels;

namespace UI.Views.Menu;

public partial class MenuPage : ContentPage
{
	public MenuPage(MenuViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}