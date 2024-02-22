using AutoMapper;
using PersonalFinanceManagementProject.DTOS.Budget;
using PersonalFinanceManagementProject.DTOS.Transaction;

namespace PersonalFinanceManagementProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Transaction, GetTransactionDTO>();

            CreateMap<AddTransactionDTO, Transaction>();

            CreateMap<Budget, GetBudgetDTO>();

            CreateMap<GetBudgetDTO, Budget>();
        }
    }
}
