using AutoMapper;
using PersonalFinanceManagementProject.Data;
using PersonalFinanceManagementProject.DTOS.Account;

namespace PersonalFinanceManagementProject.Services
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AccountService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetAccountDto>>> AddNewAccount(AddAccountDto newAccount)
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();

            var account = _mapper.Map<Account>(newAccount);

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Accounts
                .Select(acc => _mapper.Map<GetAccountDto>(acc))
                .ToListAsync();

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetAccountDto>>> DeleteAccount(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();

            var account = await  _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == id);

            try
            {
                if (account == null)
                {
                    throw new Exception($"Account with ID {id} does not exist.");
                }

                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
           
            
        }

        public async Task<ServiceResponse<GetAccountDto>> GetAccountById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAccountDto>();

            var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == id);

            serviceResponse.Data = _mapper.Map<GetAccountDto>(account);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAccountDto>>> GetAllAccounts()
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();

            var accounts = await _context.Accounts.ToListAsync();

            serviceResponse.Data = accounts
                .Select(acc => _mapper.Map<GetAccountDto>(acc))
                .ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto updatedAccount)
        {
            var serviceResponse = new ServiceResponse<GetAccountDto>();

            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == updatedAccount.Id);

                if (account == null)
                {
                    throw new Exception($"Account with ID {updatedAccount.Id} does not exist");
                }

                account.Name = updatedAccount.Name;
                account.Balance = updatedAccount.Balance;
                await _context.SaveChangesAsync();

            }catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }

            return serviceResponse;
        }
    }
}
