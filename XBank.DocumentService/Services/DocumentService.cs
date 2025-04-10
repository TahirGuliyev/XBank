using XBank.DocumentService.Data;
using XBank.DocumentService.Models;
using XBank.DocumentService.Services;
using XBank.Shared.DTOs;

public class DocumentService : IDocumentService
{
    private readonly IWebHostEnvironment _env;
    private readonly ApplicationDbContext _context;

    public DocumentService(IWebHostEnvironment env, ApplicationDbContext context)
    {
        _env = env;
        _context = context;
    }

    public async Task<Document> UploadAsync(UploadDocumentDto dto)
    {
        var file = dto.File;

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads", fileName);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        var document = new Document
        {
            CustomerId = dto.CustomerId,
            FileName = file.FileName,
            Url = $"/uploads/{fileName}",
            ContentType = file.ContentType,
            FileSize = file.Length,
            DocumentType = dto.DocumentType,
            UploadedAt = DateTime.UtcNow
        };

        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        return document;
    }
}
