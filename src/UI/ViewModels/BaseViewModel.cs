using CommunityToolkit.Mvvm.ComponentModel;

namespace UI.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title = String.Empty;

        public bool IsNotBusy => !IsBusy;
    }
}
