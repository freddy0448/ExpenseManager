using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseManager.Services;
using ExpenseManager.Views;
using Firebase.Auth;

namespace ExpenseManager.ViewModels
{
    public partial class LogInViewModel : ObservableObject
    {
        private FirebaseAuthClient _client;

        [ObservableProperty]
        Models.User user;

        private IExpenseService expenseService;

        public LogInViewModel(FirebaseAuthClient client, IExpenseService expenseService)
        {
            user = new Models.User();
            _client = client;
            this.expenseService = expenseService;
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
                    await expenseService.AddExpense();
                    await Core.Core.GoToPageAsync(nameof(MainPage));
                    User.Email = string.Empty;
                    User.Password = string.Empty;
                }
                catch (Firebase.Auth.FirebaseAuthException e)
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

        [RelayCommand]
        public async void GoToSingUp()
        {
            await Core.Core.GoToPageAsync(nameof(SingUpPage));
        }
    }
}
