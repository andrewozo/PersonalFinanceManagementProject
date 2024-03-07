using PersonalFinanceManagementProject.DTOS.Budget;

namespace PersonalFinanceManagementProject.Services
{
    public interface IBudgetService
    {
        Task<ServiceResponse<List<GetBudgetDto>>> GetAllBudgets();

        Task<ServiceResponse<GetBudgetDto>> GetBudgetById(int id);

        Task<ServiceResponse<List<GetBudgetDto>>> AddBudget(AddBudgetDto newBudget);

        Task<ServiceResponse<GetBudgetDto>> UpdateBudget(UpdateBudgetDto updatedBudget);

        Task<ServiceResponse<List<GetBudgetDto>>> DeleteBudget(int id);
    }
}
