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
        public string CountryName { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
