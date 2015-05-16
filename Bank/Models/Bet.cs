using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Bank.Models
{
    class Bet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public double amount { get; set; }
        public double odds { get; set; }
        public Competition competition { get; set; }
    }
}
