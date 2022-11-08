using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Country
    {
        public int CountoryId { get; set; }
        public string CountryName { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
