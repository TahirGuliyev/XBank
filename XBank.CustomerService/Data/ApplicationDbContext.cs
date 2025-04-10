using Microsoft.EntityFrameworkCore;
using XBank.CustomerService.Models;

namespace XBank.CustomerService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customer = modelBuilder.Entity<Customer>();
            customer.ToTable("CUSTOMERS");
            customer.Property(x => x.Id).HasColumnType("RAW(16)").HasColumnName("ID");
            customer.Property(x => x.FullName).HasColumnName("FULL_NAME");
            customer.Property(x => x.Email).HasColumnName("EMAIL");
            customer.Property(x => x.PhoneNumber).HasColumnName("PHONE_NUMBER");
            customer.Property(x => x.PhotoUrl).HasColumnName("PHOTO_URL");
            customer.Property(x => x.PhotoSize).HasColumnName("PHOTO_SIZE");
            customer.Property(x => x.PhotoFormat).HasColumnName("PHOTO_FORMAT");
            customer.Property(x => x.CreatedAt).HasColumnName("CREATED_AT");
        }

    }
}
