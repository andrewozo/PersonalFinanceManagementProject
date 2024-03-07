namespace PersonalFinanceManagementProject.DTOS.Budget
{
    public class AddBudgetDto
    {
        public decimal Amount { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
