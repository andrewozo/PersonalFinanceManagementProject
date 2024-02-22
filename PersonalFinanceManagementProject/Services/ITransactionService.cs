using PersonalFinanceManagementProject.DTOS.Transaction;

namespace PersonalFinanceManagementProject.Services
{
    public interface ITransactionService
    {
        Task<ServiceResponse<List<GetTransactionDTO>>> GetAllTransactions();

        Task<ServiceResponse<GetTransactionDTO>> GetTransactionById(int id);

        Task<ServiceResponse<List<GetTransactionDTO>>> AddTransaction(AddTransactionDTO newTransaction);
    }
}
