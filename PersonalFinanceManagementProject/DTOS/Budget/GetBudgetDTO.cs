namespace PersonalFinanceManagementProject.DTOS.Budget
{
    public class GetBudgetDTO
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
