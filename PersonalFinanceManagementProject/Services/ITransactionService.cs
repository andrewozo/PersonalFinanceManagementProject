using PersonalFinanceManagementProject.DTOS.Transaction;

namespace PersonalFinanceManagementProject.Services
{
    public interface ITransactionService
    {
        Task<List<GetTransactionDTO>> GetAllTransactions();

        Task<GetTransactionDTO> GetTransactionById(int id);

        Task<List<AddTransactionDTO>> AddTransaction(AddTransactionDTO newTransaction);
    }
}
