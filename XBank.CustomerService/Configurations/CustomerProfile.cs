using static System.Runtime.InteropServices.JavaScript.JSType;
using XBank.CustomerService.Models;
using XBank.Shared.DTOs;
using AutoMapper;

namespace XBank.CustomerService.Configurations
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerDto, Customer>();
        }
    }
}
