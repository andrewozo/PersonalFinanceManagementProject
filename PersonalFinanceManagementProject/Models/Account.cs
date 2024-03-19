namespace PersonalFinanceManagementProject.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Balance { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public List<Budget>? Budgets { get; set; }

        public List<Transaction>? Transactions { get; set; }
    }
}
