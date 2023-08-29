using ExpenseManager.ViewModels;

namespace ExpenseManager.Views;

public partial class SuggestedExpensePage : ContentPage
{
	public SuggestedExpensePage(SuggestedExpenseViewModel suggestedExpenseViewModel)
	{
		InitializeComponent();
		BindingContext = suggestedExpenseViewModel;
	}
}