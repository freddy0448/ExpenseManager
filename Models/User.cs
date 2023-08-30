namespace ExpenseManager.Models
{
    public class User
    {
        public int Id{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsANewUser{ get; set; }
        public double Salary{ get; set; }
        public double RemainingSalary { get; set; }
    }
}
