using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XBank.Shared.DTOs;
using XBank.TransactionService.Services;

namespace XBank.TransactionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto dto)
        {
            var result = await _service.CreateTransactionAsync(dto);
            return Ok(result);
        }
    }
}
