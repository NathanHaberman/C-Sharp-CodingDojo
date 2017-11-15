using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TheDojoLeague.Models
{
    public class Dojo : BaseEntity
    {

        public int id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public List<Ninja> Ninjas { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}