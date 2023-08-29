using ExpenseManager.ViewModels;

namespace ExpenseManager.Views;

public partial class AddExpensePage : ContentPage
{
	public AddExpensePage(AddExpenseViewModel addExpenseViewModel)
	{
		InitializeComponent();
		BindingContext = addExpenseViewModel;
	}
}