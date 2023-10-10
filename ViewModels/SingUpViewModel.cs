using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
            else if (User.Password.Length < 6) await Shell.Current.DisplayAlert("Mensaje", "La contraseña debe de tener mínimo 6 caracteres", "OK");
            else
            {
                try
                {
                    var result = await client.CreateUserWithEmailAndPasswordAsync(User.Email, PasswordConf);
                    await Shell.Current.DisplayAlert("Mensaje", "Usuario registrado exitosamente", "OK");

                    await Core.Core.GoToPageWithUserDataAsync(nameof(MainPage), User);

                }
                catch (Firebase.Auth.FirebaseAuthException e)
                {
                    await Shell.Current.DisplayAlert("Error", e.Reason.ToString(), "OK");
                }
            }
        }


    }
}
