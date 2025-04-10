using Microsoft.AspNetCore.Mvc;
using XBank.DocumentService.Services;
using XBank.Shared.DTOs;

namespace XBank.DocumentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _service;

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadDocumentDto dto)
        {
            var result = await _service.UploadAsync(dto);
            return Ok(result);
        }
    }
}
