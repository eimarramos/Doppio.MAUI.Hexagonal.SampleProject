using UI.ViewModels;

namespace UI.Views.Promotions;

public partial class PromotionsPage : ContentPage
{
	public PromotionsPage(PromotionsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}