using Moq;
using Xunit;
using XBank.CustomerService.Services;
using XBank.CustomerService.Models;
using XBank.CustomerService.Repositories;
using XBank.Shared.DTOs;
using System.Threading.Tasks;

namespace XBank.Tests
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _mockRepo;
        private readonly XBank.CustomerService.Services.CustomerService _customerService;

        public CustomerServiceTests()
        {
            _mockRepo = new Mock<ICustomerRepository>();
            _customerService = new XBank.CustomerService.Services.CustomerService(_mockRepo.Object, null, null); 
        }

        [Fact]
        public async Task CreateCustomerAsync_ShouldReturnCustomer()
        {
            var dto = new CreateCustomerDto
            {
                FullName = "Tahir Guliyev",
                Email = "tahirguliyev95@gmail.com",
                PhoneNumber = "+994111111111"
            };

            var customer = new Customer
            {
                Id = new Guid(),
                FullName = "Tahir Guliyev",
                Email = "tahirguliyev95@gmail.com",
                PhoneNumber = "+994111111111"
            };

            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Customer>())).Returns(Task.CompletedTask);

            var result = await _customerService.CreateCustomerAsync(dto);

            Assert.Equal(dto.FullName, result.FullName);
            Assert.Equal(dto.Email, result.Email);
            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Customer>()), Times.Once);
        }
    }
}
