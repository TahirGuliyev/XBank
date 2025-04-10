using Moq;
using Xunit;
using XBank.TransactionService.Services;
using XBank.TransactionService.Models;
using XBank.TransactionService.Repositories;
using XBank.Shared.DTOs;
using System;
using System.Threading.Tasks;

namespace XBank.Tests
{
    public class TransactionServiceTests
    {
        private readonly Mock<ITransactionRepository> _mockRepo;
        private readonly XBank.TransactionService.Services.TransactionService _transactionService;

        public TransactionServiceTests()
        {
            _mockRepo = new Mock<ITransactionRepository>();
            _transactionService = new XBank.TransactionService.Services.TransactionService(_mockRepo.Object, null, null);
        }

        [Fact]
        public async Task CreateTransactionAsync_ShouldReturnTransaction()
        {
            var dto = new CreateTransactionDto
            {
                CustomerId = Guid.NewGuid(),
                Type = "Deposit",
                Amount = 1000.00M
            };

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = dto.CustomerId,
                Type = dto.Type,
                Amount = dto.Amount,
                Timestamp = DateTime.UtcNow
            };

            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Transaction>())).Returns(Task.CompletedTask);

            var result = await _transactionService.CreateTransactionAsync(dto);

            Assert.Equal(dto.CustomerId, result.CustomerId);
            Assert.Equal(dto.Type, result.Type);
            Assert.Equal(dto.Amount, result.Amount);
            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Transaction>()), Times.Once);
        }
    }
}
