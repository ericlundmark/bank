using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bank.Utility;

namespace Bank.Models
{
    public class Provider : Model
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public ProviderState State { get; set; }
    }
}