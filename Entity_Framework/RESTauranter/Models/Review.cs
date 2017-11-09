using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Review
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Your Name")]
        public string reviewer { get; set; }

        [Required]
        [Display(Name = "Resturant")]
        public string name { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Name = "Your Review")]
        public string theMeat { get; set; }

        [Required]
        [Display(Name = "Date Visited")]
        public DateTime visitDate { get; set; }

        [Required]
        [Display(Name = "Stars")]
        public int stars { get; set; }
    }
}
