using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class Spreadsheet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public ApplicationUser creator { get; set; }
        public DateTime created { get; set; }
        public float roi { get; set; }
        public double balance { get; set; }
        public double investment { get; set; }
        public IList<Bet> bets { get; set; }
    }
}