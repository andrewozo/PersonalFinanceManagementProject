namespace PersonalFinanceManagementProject.DTOS.Transaction
{
    public class UpdateTransactionDto
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; } = string.Empty;
    }
}
