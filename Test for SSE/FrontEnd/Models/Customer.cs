using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public int MaterialStatus { get; set; }

        public string PhotoUrl { get; set; }

        //  public string CustomerPhoto { get; set; }

        public List<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();



        [Required(ErrorMessage = "Please choose the Profile Photo")]
        [Display(Name = "Profile Photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

    }
}
