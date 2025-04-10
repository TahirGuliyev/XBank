using Microsoft.EntityFrameworkCore;
using XBank.TransactionService.Models;

namespace XBank.TransactionService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Transaction>();
            entity.ToTable("TRANSACTIONS");
            entity.Property(x => x.Id).HasColumnType("RAW(16)").HasColumnName("ID");
            entity.Property(x => x.CustomerId).HasColumnType("RAW(16)").HasColumnName("CUSTOMER_ID");
            entity.Property(x => x.Type).HasColumnName("TYPE");
            entity.Property(x => x.Amount).HasColumnName("AMOUNT");
            entity.Property(x => x.Timestamp).HasColumnName("TIMESTAMP");
        }
    }
}
