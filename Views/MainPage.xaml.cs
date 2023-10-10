using ExpenseManager.Models;
using ExpenseManager.Services;
using ExpenseManager.ViewModels;

namespace ExpenseManager
{
    [QueryProperty(nameof(UserDetails), "UserDetails")]
    public partial class MainPage : ContentPage
    {
        public User UserDetails { get; set; }
        private IUserService userService;
        public MainPage(MainViewModel mainViewModel, IUserService _userService)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
            userService = _userService;
        }
    }
}