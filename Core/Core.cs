using ExpenseManager.Models;

namespace ExpenseManager.Core
{
    public static class Core
    {
        public static async Task GoToPageAsync(string pageName)
        {
            await Shell.Current.GoToAsync(pageName);
        }

        public static async Task GoToPageWithUserDataAsync(string pageName, User data)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("UserDetails", data);

            await Shell.Current.GoToAsync(pageName, dictionary);
        }
    }
}
