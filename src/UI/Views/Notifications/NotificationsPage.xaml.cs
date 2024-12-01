using UI.ViewModels;

namespace UI.Views.Notifications;

public partial class NotificationsPage : ContentPage
{
	public NotificationsPage(NotificationsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}