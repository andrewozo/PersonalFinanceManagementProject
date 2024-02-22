using AutoMapper;
using PersonalFinanceManagementProject.Data;
using PersonalFinanceManagementProject.DTOS.Transaction;

namespace PersonalFinanceManagementProject.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TransactionService(IMapper mapper, DataContext context) {
            _mapper = mapper;

            _context = context;
        }
        public async Task<ServiceResponse<List<GetTransactionDTO>>> AddTransaction(AddTransactionDTO newTransaction)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDTO>>();

           var transaction = _mapper.Map<Transaction>(newTransaction);
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context
                .Transactions
                .Select(action => _mapper.Map<GetTransactionDTO>(action))
                .ToListAsync();

            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetTransactionDTO>>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetTransactionDTO>> GetTransactionById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
