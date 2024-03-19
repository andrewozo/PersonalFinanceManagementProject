using AutoMapper;
using PersonalFinanceManagementProject.Data;
using PersonalFinanceManagementProject.DTOS.Budget;
using System.Security.Claims;

namespace PersonalFinanceManagementProject.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BudgetService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        public async Task<ServiceResponse<List<GetBudgetDto>>> AddBudget(AddBudgetDto newBudget)
        {
            var serviceResponse = new ServiceResponse<List<GetBudgetDto>>();

            var budget = _mapper.Map<Budget>(newBudget);

            var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.UserId == GetUserId());

            budget.Account = account;

            _context.Budgets.Add(budget);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Budgets
                .Select(action => _mapper.Map<GetBudgetDto>(action))
                .ToListAsync();

            return serviceResponse;
        
        }

        public async Task<ServiceResponse<List<GetBudgetDto>>> DeleteBudget(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetBudgetDto>>();

            try
            {
                var budget = await _context.Budgets.FirstOrDefaultAsync(budget => budget.Id == id);

                if (budget == null)
                {
                    throw new Exception($"Budget with id {id} not found");
                }

                _context.Budgets.Remove(budget);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Budgets
                    .Select(budget => _mapper.Map<GetBudgetDto>(budget))
                    .ToListAsync();

            }catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;


            }

            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<GetBudgetDto>>> GetAllBudgets()
        {
            var serviceResponse = new ServiceResponse<List<GetBudgetDto>>();

            var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.UserId == GetUserId());



            var budgets = await _context.Budgets.Where(budg => budg.Account!.Id == account!.Id).ToListAsync();

            serviceResponse.Data = budgets.Select(budget => _mapper.Map<GetBudgetDto>(budget))
                .ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBudgetDto>> GetBudgetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetBudgetDto>();

            var budget = await _context.Budgets.FirstOrDefaultAsync(budg => budg.Id == id);

            serviceResponse.Data = _mapper.Map<GetBudgetDto>(budget);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBudgetDto>> UpdateBudget(UpdateBudgetDto updatedBudget)
        {
            var serviceResponse = new ServiceResponse<GetBudgetDto>();

            try
            {
                var budget = await _context.Budgets.FirstOrDefaultAsync(budg => budg.Id == updatedBudget.Id);

                if (budget == null)
                {
                    throw new Exception($"Budget by the Id {updatedBudget.Id} was not found");
                }

                budget.Amount = updatedBudget.Amount;
                budget.Message = updatedBudget.Message;

            }catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
