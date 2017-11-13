using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Bank_Accounts.Models
{
    public class User
    {
        public int id { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public int Balance { get; set; }

        public List<Transaction> Transactions { get; set; }

        public User()
        {
            Transactions = new List<Transaction>();
            Balance = 1000;
        }
    }
}