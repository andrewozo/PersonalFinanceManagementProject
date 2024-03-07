﻿namespace PersonalFinanceManagementProject.DTOS.Account
{
    public class GetAccountDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Balance { get; set; }
    }
}
