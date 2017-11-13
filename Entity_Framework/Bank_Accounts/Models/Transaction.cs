using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Bank_Accounts.Models
{
    public class Transaction
    {
        public int id { get; set; }

        public int Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}