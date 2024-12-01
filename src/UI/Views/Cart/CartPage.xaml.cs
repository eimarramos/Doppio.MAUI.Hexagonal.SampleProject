using UI.ViewModels;

namespace UI.Views.Cart;

public partial class CartPage : ContentPage
{
	public CartPage(CartViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}