using ExpenseManager.ViewModels;
using ExpenseManager.Views;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;

namespace ExpenseManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<AddExpensePage>();
            builder.Services.AddSingleton<AddExpenseViewModel>();
            builder.Services.AddSingleton<SuggestedExpensePage>();
            builder.Services.AddSingleton<SuggestedExpenseViewModel>();

            //firebase
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyDAYil8K3XdcP5MZKXyLnjJ-ZFUhVMJAyc",
                AuthDomain = "expensemanager-fb00e.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            })); 



            return builder.Build();
        }
    }
}