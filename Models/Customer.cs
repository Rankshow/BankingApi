namespace BankingApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public double AccountNo { get; set; }
        public string? Country { get; set; }
    }
}