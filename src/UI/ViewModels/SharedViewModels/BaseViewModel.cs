using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModels.SharedViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool _isBusy;

        [ObservableProperty]
        private string _title = String.Empty;

        public bool IsNotBusy => !IsBusy;

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
