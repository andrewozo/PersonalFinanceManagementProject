using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceManagementProject.DTOS.Account;
using PersonalFinanceManagementProject.Services;

namespace PersonalFinanceManagementProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetAccountDto>>>> GetAllAccounts()
        {
            return Ok(await _accountService.GetAllAccounts());
        }

        [HttpGet("PrintReport")]
        public async Task<ActionResult<string>> PrintReport()
        {
            return Ok(await _accountService.PrintReport());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> GetSingleAccount(int id)
        {
            return Ok(await _accountService.GetAccountById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAccountDto>>>> AddAccount(AddAccountDto newAccount)
        {
            return Ok(await _accountService.AddNewAccount(newAccount));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> UpdateAccount(UpdateAccountDto newAccount)
        {
            var response = await _accountService.UpdateAccount(newAccount);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ServiceResponse<List<GetAccountDto>>>> DeleteAccount (int id)
        {
            var response = await _accountService.DeleteAccount(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);

        }


    }
}
