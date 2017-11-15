using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        public Wedding()
        {
            Guests = new List<Guest>();
        }

        public int id { get; set; }

        public string Wedder1 { get; set; }

        public string Wedder2 { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }
        
        public List<Guest> Guests { get; set; }
    }

    public class WeddingVM : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "Wedder One")]
        public string Wedder1 { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Wedder Two")]
        public string Wedder2 { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Address { get; set; }
    }
}