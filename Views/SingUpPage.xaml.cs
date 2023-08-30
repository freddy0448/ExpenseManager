using ExpenseManager.ViewModels;

namespace ExpenseManager.Views;

public partial class SingUpPage : ContentPage
{
	public SingUpPage(SingUpViewModel singUpViewModel)
	{
		InitializeComponent();
		BindingContext = singUpViewModel;
	}
}