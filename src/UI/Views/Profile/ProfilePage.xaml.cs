using UI.ViewModels;

namespace UI.Views.Profile;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}