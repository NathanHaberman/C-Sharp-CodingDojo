using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            Attending = new List<Guest>();
            Owning = new List<Wedding>();
        }

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

        List<Guest> Attending { get; set; }

        List<Wedding> Owning { get; set; }
    }

    public class RegisterVM : BaseEntity
    {
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
        public string RegEmail { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string RegPassword { get; set; }

        [Required]
        [Compare("RegPassword")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginVM : BaseEntity
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string LoginEmail { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string LoginPassword { get; set; }
    }

    public class Wrapper : BaseEntity
    {
        // public Wrapper()
        // {
        //     Register = new RegisterVM();
        //     Login = new LoginVM();
        // }
        public RegisterVM Register { get; set; }

        public LoginVM Login { get; set; }
    }
}