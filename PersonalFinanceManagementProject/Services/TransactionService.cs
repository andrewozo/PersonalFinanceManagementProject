using PersonalFinanceManagementProject.DTOS.Transaction;

namespace PersonalFinanceManagementProject.Services
{
    public class TransactionService : ITransactionService
    {
        public Task<List<AddTransactionDTO>> AddTransaction(AddTransactionDTO newTransaction)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetTransactionDTO>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<GetTransactionDTO> GetTransactionById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
