using Microsoft.Identity.Client;
using PersonalFinanceManagementProject.DTOS.Account;

namespace PersonalFinanceManagementProject.Services
{
    public interface IAccountService
    {
        Task<ServiceResponse<List<GetAccountDto>>> GetAllAccounts();

         Task<ServiceResponse<GetAccountDto>> GetAccountById(int id);

        Task<ServiceResponse<List<GetAccountDto>>> AddNewAccount(AddAccountDto newAccount);

        Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto updatedAccount);

        Task<ServiceResponse<List<GetAccountDto>>> DeleteAccount(int id);


    }
}
