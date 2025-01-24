using CommunityToolkit.Mvvm.Input;
using UI.ViewModels.SharedViewModels;

namespace UI.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
        }

        [RelayCommand]
        private async Task GoToHome()
        {
            await Task.Run(async () =>
            {
                try
                {
                    IsBusy = true;

                    await Shell.Current.GoToAsync("///home");
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }
    }
}
