using System.ComponentModel.DataAnnotations;


namespace BankingApi.Dto.Account
{
    public class DeleteAccountRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? AccountType { get; set; }
    }
}