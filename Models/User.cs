namespace ExpenseManager.Models
{
    public class User
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsANewUser{ get; set; }
        public double Salary{ get; set; }
        public double RemainingSalary { get; set; }
    }
}
