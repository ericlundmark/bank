using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class Spreadsheet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public ApplicationUser Creator { get; set; }

        public DateTimeOffset Created { get; set; }
        public float Roi { get; set; }
        public double Balance { get; set; }
        public double Investment { get; set; }
        public IList<Wager> Wagers { get; set; }

        public Spreadsheet()
        {
            this.Created = DateTimeOffset.Now;
        }
    }
}