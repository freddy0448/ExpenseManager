using ExpenseManager.ViewModels;

namespace ExpenseManager.Views;

public partial class LogInPage : ContentPage
{
	public LogInPage(LogInViewModel logInViewModel)
	{
		InitializeComponent();
		BindingContext = logInViewModel;
	}
}