using PersonalFinanceManagementProject.DTOS.Budget;
using PersonalFinanceManagementProject.DTOS.Transaction;
using PersonalFinanceManagementProject.DTOS.User;

namespace PersonalFinanceManagementProject.DTOS.Account
{
    public class GetAccountDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Balance { get; set; }

        public GetUserDto? User { get; set; }

        public List<GetBudgetDto>? Budgets { get; set; }

        public List<GetTransactionDto>? Transactions { get; set; }


    }
}
