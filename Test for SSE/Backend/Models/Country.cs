using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Country
    {
        [Key]
        public int CountoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
