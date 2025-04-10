using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XBank.CustomerService.Services;
using XBank.Shared.DTOs;

namespace XBank.CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCustomerDto dto)
        {
            var customer = await _service.CreateCustomerAsync(dto);
            return Ok(customer);
        }
    }
}
