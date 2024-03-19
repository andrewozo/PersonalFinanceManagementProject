using AutoMapper;
using PersonalFinanceManagementProject.Data;
using PersonalFinanceManagementProject.DTOS.Transaction;
using System.Security.Claims;

namespace PersonalFinanceManagementProject.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TransactionService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor) {
            _mapper = mapper;

            _context = context;

            _httpContextAccessor = httpContextAccessor;
        }


        private int GetUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }


        public async Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto newTransaction)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();

           var transaction = _mapper.Map<Transaction>(newTransaction);

            var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.UserId == GetUserId());

            transaction.Account = account;
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();


            serviceResponse.Data = 
                await _context
                .Transactions
                .Select(action => _mapper.Map<GetTransactionDto>(action))
                .ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();  

            try
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);

                if (transaction == null)
                {
                    throw new Exception($"Transaction with Id {id} not found");
                }

                _context.Transactions.Remove(transaction);

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context
                    .Transactions
                    .Select(transaction => _mapper.Map<GetTransactionDto>(transaction))
                    .ToListAsync();

            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> GetAllTransactions()
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();

            var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.UserId == GetUserId());


            
            var transactions = await _context.Transactions.Where(t => t.Account!.Id == account!.Id).ToListAsync();

            serviceResponse.Data = transactions
                .Select(t => _mapper.Map<GetTransactionDto>(t))
                .ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransactionDto>> GetTransactionById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();

            var dbTransaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);

            serviceResponse.Data = _mapper.Map<GetTransactionDto>(dbTransaction);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransactionDto>> UpdateTransaction(UpdateTransactionDto updateTransaction)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();

            try
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == updateTransaction.Id);

                if (transaction == null)
                {
                    throw new Exception($"Transaction with Id {updateTransaction.Id} not found");
                }

                transaction.Amount = updateTransaction.Amount;
                transaction.Date = updateTransaction.Date;
                transaction.Category = updateTransaction.Category; 

            }catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
