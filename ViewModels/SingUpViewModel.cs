using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseManager.Views;
using Firebase.Auth;

namespace ExpenseManager.ViewModels
{
    public partial class SingUpViewModel : ObservableObject
    {
        FirebaseAuthClient client;

        [ObservableProperty]
        Models.User user;

        [ObservableProperty]
        string _passwordConf;

        public SingUpViewModel(FirebaseAuthClient client)
        {
            this.client = client;
            User = new Models.User();
        }

        [RelayCommand]
        public async Task SingUpAsync()
        {
            if (string.IsNullOrEmpty(User.Password)) await Shell.Current.DisplayAlert("Mensaje", "Debe de ingresar una contraseña", "OK");
            else if (User.Password != PasswordConf) await Shell.Current.DisplayAlert("Mensaje", "La contraseña y la confirmación de contraseña son distintas", "OK");
            else
            {
                try
                {
                    await client.CreateUserWithEmailAndPasswordAsync(User.Email, PasswordConf);
                    await Shell.Current.DisplayAlert("Mensaje", "Usuario registrado exitosamente", "OK");
                    User.Email = string.Empty;
                    User.Password = string.Empty;
                    PasswordConf = string.Empty;
                    await Core.GoToPageAsync(nameof(LogInPage));

                }
                catch (Exception)
                {
                    await Shell.Current.DisplayAlert("Mensaje", "Hubo un error a la hora de registrarlo", "OK");
                    throw;
                }
            }
        }
    }
}
