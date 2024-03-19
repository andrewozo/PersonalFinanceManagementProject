using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceManagementProject.DTOS.Transaction;
using PersonalFinanceManagementProject.Services;

namespace PersonalFinanceManagementProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> GetAllTransactions()
        {
            return Ok(await _transactionService.GetAllTransactions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> GetSingleTransaction(int id)
        {
            return Ok(await _transactionService.GetTransactionById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> AddTransaction(AddTransactionDto transaction)
        {
            return Ok(await _transactionService.AddTransaction(transaction));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> UpdateTransaction(UpdateTransactionDto updateTransaction)
        {
            var response = await _transactionService.UpdateTransaction(updateTransaction);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> DeleteTransaction(int id)
        {
            var response = await _transactionService.DeleteTransaction(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(Response);
        }






    }
}
