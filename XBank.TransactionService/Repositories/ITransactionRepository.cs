using XBank.TransactionService.Models;

namespace XBank.TransactionService.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllAsync();
    }
}
