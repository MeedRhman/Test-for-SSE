using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class CustomerAddress
    {
        public int CustomerAddressId { get; set; }

        public string customerAddress { get; set; }


        public int CustomerId { get; set; }


        public Customer Customer { get; set; }


    }
}
