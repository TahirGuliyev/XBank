using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using XBank.DocumentService.Models;

namespace XBank.DocumentService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Document> Documents => Set<Document>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var doc = modelBuilder.Entity<Document>();
            doc.ToTable("DOCUMENTS");
            doc.Property(x => x.Id).HasColumnType("RAW(16)").HasColumnName("ID");
            doc.Property(x => x.CustomerId).HasColumnType("RAW(16)").HasColumnName("CUSTOMER_ID");
            doc.Property(x => x.FileName).HasColumnName("FILE_NAME");
            doc.Property(x => x.Url).HasColumnName("URL");
            doc.Property(x => x.ContentType).HasColumnName("CONTENT_TYPE");
            doc.Property(x => x.DocumentType).HasColumnName("DOCUMENT_TYPE");
            doc.Property(x => x.FileSize).HasColumnName("FILE_SIZE");
            doc.Property(x => x.UploadedAt).HasColumnName("UPLOADED_AT");
        }
    }
}
