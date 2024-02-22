namespace PersonalFinanceManagementProject.Models
{
    public class Transaction
    {
        public decimal Amount { get; set; }

        public DateTime? Date { get; set; }

        public string Category { get; set; } = String.Empty;
    }
}
