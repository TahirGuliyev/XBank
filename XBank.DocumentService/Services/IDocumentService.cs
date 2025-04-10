using XBank.DocumentService.Models;
using XBank.Shared.DTOs;

namespace XBank.DocumentService.Services
{
    public interface IDocumentService
    {
        Task<Document> UploadAsync(UploadDocumentDto dto);
    }
}
