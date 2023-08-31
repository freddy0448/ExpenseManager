using ExpenseManager.Models;
using SQLite;

namespace ExpenseManager.Services
{
    public class UserService
    {
        private SQLiteAsyncConnection db;
        private void Init()
        {
            if (db != null)
                return;

            var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "User.db");
            db = new SQLiteAsyncConnection(dataBasePath);

            db.CreateTableAsync<User>();
        }

        public async Task<List<User>> GetUsers(User user)
        {
            Init();

            var getResult = await db.Table<User>().ToListAsync();

            return getResult;
        }

        public async Task<int> InsertUser(User user) 
        {
            Init();

            var result = await db.InsertAsync(user);
            return result;
        }


    }
}
