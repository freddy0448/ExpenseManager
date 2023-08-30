using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth;
using System.Reflection.Metadata;

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


        public async Task LogInAsync()
        {
            if (string.IsNullOrEmpty(User.Email) || string.IsNullOrEmpty(User.Password))
                await Shell.Current.DisplayAlert("Mensaje", "El usuario y/o contraseña están vacios", "OK");
            else
            {
                try
                {
                    await _client.SignInWithEmailAndPasswordAsync(User.Email, User.Password);
                    await Core.GoToPageAsync(nameof(MainPage));
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
}
