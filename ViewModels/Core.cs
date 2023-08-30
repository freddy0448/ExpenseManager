namespace ExpenseManager.ViewModels
{
    public static class Core
    {
        public static async Task GoToPageAsync(string pageName)
        {
            await Shell.Current.GoToAsync(pageName);
        }
    }
}
