using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using XBank.CustomerService.Models;
using XBank.CustomerService.Repositories;
using XBank.Shared.DTOs;

namespace XBank.CustomerService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public CustomerService(
            ICustomerRepository repo,
            IWebHostEnvironment env,
            IMapper mapper)
        {
            _repo = repo;
            _env = env;
            _mapper = mapper;
        }

        public async Task<Customer> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            if (dto.ProfilePhoto != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.ProfilePhoto.FileName)}";
                var filePath = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                using var stream = new FileStream(filePath, FileMode.Create);
                await dto.ProfilePhoto.CopyToAsync(stream);

                customer.PhotoUrl = $"/uploads/{fileName}";
                customer.PhotoSize = dto.ProfilePhoto.Length; 
                customer.PhotoFormat = dto.ProfilePhoto.ContentType; 
            }

            await _repo.AddAsync(customer);
            return customer;
        }
    }
}
