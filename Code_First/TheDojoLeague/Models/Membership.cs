using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TheDojoLeague.Models
{
    public class Membership : BaseEntity
    {
        
        public int id { get; set; }

        public int DojoId { get; set; }
        
        public Dojo Dojo { get; set; }

        public int NinjaId { get; set; }

        public Ninja Ninja { get; set; }

        public int PendingNinjaId { get; set; }

        public Ninja PendingNinja { get; set; }
    }
}