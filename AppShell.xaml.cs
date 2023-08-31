using ExpenseManager.Views;

namespace ExpenseManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
            Routing.RegisterRoute(nameof(SingUpPage), typeof(SingUpPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));


        }
    }
}