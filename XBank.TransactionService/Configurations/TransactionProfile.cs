using AutoMapper;
using XBank.Shared.DTOs;
using XBank.TransactionService.Models;

namespace XBank.TransactionService.Configurations
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<CreateTransactionDto, Transaction>();
        }
    }
}
