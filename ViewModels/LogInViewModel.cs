using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace ExpenseManager.ViewModels
{
    public partial class LogInViewModel : ObservableObject
    {
        private FirebaseAuthClient _client;

        [ObservableProperty]
        Models.User user;

        public LogInViewModel(FirebaseAuthClient client)
        {
            user = new Models.User();
            _client = client;
        }

        [RelayCommand]
        public async Task LogInAsync()
        {
            if (!VerifyLogIn())
                await Shell.Current.DisplayAlert("Mensaje", "El usuario y/o contraseña están vacios", "OK");
            else
            {
                try
                {
                    var result = await _client.SignInWithEmailAndPasswordAsync(User.Email, User.Password);
                    await Core.GoToPageAsync(nameof(MainPage));
                    User.Email = string.Empty;
                    User.Password = string.Empty;
                }
                catch (FirebaseAuthException e)
                {
                    await Shell.Current.DisplayAlert("Mensaje", e.Reason.ToString(), "OK");
                }
            }

        }

        private bool VerifyLogIn()
        {
            if (string.IsNullOrEmpty(User.Email) || string.IsNullOrEmpty(User.Password))
                return false;
            else
                return true;
        }
    }
}
