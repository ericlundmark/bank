using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class Spreadsheet : Model
    {
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        [Required]
        public ApplicationUser Creator { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double? Investment { get; set; }

        [DefaultValue(100f)]
        public float Roi { get; set; }

        [DataType(DataType.Currency)]
        public double? Balance { get; set; }

        public IList<Wager> Wagers { get; set; }

        public Spreadsheet()
        {
            Balance = Investment;
        }
    }
}