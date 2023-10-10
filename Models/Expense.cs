namespace ExpenseManager.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double ExpenseQuantity { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }
}
