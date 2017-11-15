using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TheDojoLeague.Models
{
    public class Ninja : BaseEntity
    {

        public int id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}