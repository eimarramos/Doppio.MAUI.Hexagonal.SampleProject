using UI.ViewModels;

namespace UI.Views.Home;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}