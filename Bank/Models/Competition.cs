using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Bank.Models
{
    class Competition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public String home { get; set; }
        public String away { get; set; }
        public DateTime dateTime { get; set; }
    }
}
