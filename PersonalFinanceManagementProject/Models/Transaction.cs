﻿namespace PersonalFinanceManagementProject.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public DateTime? Date { get; set; }

        public string Category { get; set; } = String.Empty;

        public Account? Account { get; set; }
    }
}
