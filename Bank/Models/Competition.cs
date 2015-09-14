using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class Competition : Model
    {
        public string ExternalId { get; set; }
        public Provider Provider { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public DateTime DateTime { get; set; }
        public Outcome Outcome { get; set; }
    }
}