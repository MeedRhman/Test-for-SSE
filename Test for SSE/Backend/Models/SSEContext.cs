using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class SSEContext :DbContext
    {
        public SSEContext(DbContextOptions<SSEContext> options) :base(options)
        {

        }

        public DbSet<Country> Countories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerAddress> CustomersAdresses { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You don't actually ever need to call this
        }
        */
    }
}
