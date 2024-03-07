namespace PersonalFinanceManagementProject.DTOS.Budget
{
    public class UpdateBudgetDto
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
