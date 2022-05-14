using System.ComponentModel.DataAnnotations;

namespace BookStore1.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Display(Name ="User name")]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        public string? AccountType { get; set; } = "User";
    }
}
