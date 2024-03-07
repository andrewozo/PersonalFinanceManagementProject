using AutoMapper;
using PersonalFinanceManagementProject.DTOS.Budget;
using PersonalFinanceManagementProject.DTOS.Transaction;

namespace PersonalFinanceManagementProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Transaction, GetTransactionDto>();

            CreateMap<AddTransactionDto, Transaction>();

            CreateMap<Budget, GetBudgetDto>();

            CreateMap<GetBudgetDto, Budget>();
        }
    }
}
