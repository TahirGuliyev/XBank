using AutoMapper;
using XBank.Shared.DTOs;
using XBank.TransactionService.Models;
using XBank.TransactionService.Repositories;
using XBank.Shared.Events;
using XBank.EventBus.Abstractions;

namespace XBank.TransactionService.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repo;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;

        public TransactionService(
            ITransactionRepository repo,
            IMapper mapper,
            IEventBus eventBus)
        {
            _repo = repo;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        public async Task<Transaction> CreateTransactionAsync(CreateTransactionDto dto)
        {
            var transaction = _mapper.Map<Transaction>(dto);

            await _repo.AddAsync(transaction);

            var @event = new TransactionCreatedEvent
            {
                CustomerId = transaction.CustomerId,
                Amount = transaction.Amount,
                Type = transaction.Type
            };

            _eventBus.Publish(@event);

            return transaction;
        }
    }
}
