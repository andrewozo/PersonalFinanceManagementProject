﻿namespace PersonalFinanceManagementProject.DTOS.Budget
{
    public class AddBudgetDTO
    {
        public decimal Amount { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
