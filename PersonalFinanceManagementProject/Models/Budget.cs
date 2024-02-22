namespace PersonalFinanceManagementProject.Models
{
    public class Budget
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
