using UI.ViewModels;

namespace UI.Views.ShopDetails;

public partial class ShopDetailsPage : ContentPage
{
	public ShopDetailsPage(ShopDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}