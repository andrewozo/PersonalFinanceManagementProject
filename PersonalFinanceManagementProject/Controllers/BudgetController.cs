using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceManagementProject.DTOS.Budget;
using PersonalFinanceManagementProject.Services;

namespace PersonalFinanceManagementProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService) 
        {
            _budgetService = budgetService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<GetBudgetDto>>> GetAllBudgets()
        {
            return Ok(await _budgetService.GetAllBudgets());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetBudgetDto>>> GetSingleBudget(int id)
        {
            return Ok(await _budgetService.GetBudgetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetBudgetDto>>>> AddBudget(AddBudgetDto newBudget)
        {
            return Ok(await _budgetService.AddBudget(newBudget));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetBudgetDto>>>> UpdateBudget(UpdateBudgetDto updatedBudget)
        {
           var response = await _budgetService.UpdateBudget(updatedBudget);

            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetBudgetDto>>> DeleteBudget(int id)
        {
            var response = await _budgetService.DeleteBudget(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
