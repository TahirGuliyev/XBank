namespace XBank.CustomerService.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? PhotoUrl { get; set; }
        public long? PhotoSize { get; set; }
        public string? PhotoFormat { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
