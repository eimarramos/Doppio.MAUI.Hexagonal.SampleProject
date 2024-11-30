using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
        }

        [RelayCommand]
        public async Task GoToHome()
        {
            try
            {
                IsBusy = true;

                await Shell.Current.GoToAsync("///Home");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
