using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
