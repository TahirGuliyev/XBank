using XBank.TransactionService.Models;
using XBank.Shared.DTOs;

namespace XBank.TransactionService.Services
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransactionAsync(CreateTransactionDto dto);
    }
}
