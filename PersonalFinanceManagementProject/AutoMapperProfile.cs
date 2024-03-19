using AutoMapper;
using PersonalFinanceManagementProject.DTOS.Account;
using PersonalFinanceManagementProject.DTOS.Budget;
using PersonalFinanceManagementProject.DTOS.Transaction;
using PersonalFinanceManagementProject.DTOS.User;

namespace PersonalFinanceManagementProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Transaction, GetTransactionDto>();

            CreateMap<AddTransactionDto, Transaction>();

            CreateMap<Budget, GetBudgetDto>();

            CreateMap<AddBudgetDto, Budget>();

            CreateMap<Account, GetAccountDto>();

            CreateMap<AddAccountDto, Account>();

            CreateMap<User,GetUserDto>();
        }
    }
}
