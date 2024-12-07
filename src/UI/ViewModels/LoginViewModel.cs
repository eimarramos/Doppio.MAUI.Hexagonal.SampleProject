using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
        }

        [RelayCommand]
        private void GoToHome()
        {
            Task.Run(async () =>
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
