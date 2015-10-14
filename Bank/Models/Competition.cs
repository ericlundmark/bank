using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class Competition : Model
    {
        public string ExternalId { get; set; }
        public Provider Provider { get; set; }
        public IEnumerable<string> Participants { get; set; }
        public DateTime DateTime { get; set; }
        public Outcome Outcome { get; set; }
    }
}