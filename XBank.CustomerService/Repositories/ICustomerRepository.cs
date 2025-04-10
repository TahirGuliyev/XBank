using XBank.CustomerService.Models;

namespace XBank.CustomerService.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
