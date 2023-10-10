namespace ExpenseManager.Services
{
    public interface IExpenseService
    {
        public Task AddExpense();
        public Task DeleteExpense();
        public Task GetExpense();
        public Task UpdateExpense();

    }
}
