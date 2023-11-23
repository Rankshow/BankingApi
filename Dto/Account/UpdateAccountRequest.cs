using System.ComponentModel.DataAnnotations;

namespace BankingApi.Dto.Account
{
    public class UpdateAccountRequest
    {
        [Required]
        public int Id { set; get; }
        [Required]
        public string? Name { set; get; }
        [Required]
        public string? AccountType { set; get; }
    }
}