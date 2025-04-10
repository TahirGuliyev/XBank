using XBank.CustomerService.Models;
using XBank.Shared.DTOs;

namespace XBank.CustomerService.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(CreateCustomerDto dto);
    }
}
