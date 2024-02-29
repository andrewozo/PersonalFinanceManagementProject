﻿namespace PersonalFinanceManagementProject.DTOS.Transaction
{
    public class AddTransactionDto
    {
        

        public decimal Amount { get; set; }

        public DateTime Date {  get; set; }

        public string Category { get; set; } = string.Empty;
    }
}
