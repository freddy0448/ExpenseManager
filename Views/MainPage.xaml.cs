using ExpenseManager.ViewModels;

namespace ExpenseManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
            
        }

    }
}