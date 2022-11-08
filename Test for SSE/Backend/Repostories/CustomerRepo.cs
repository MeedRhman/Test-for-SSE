using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repostories
{
    public class CustomerRepo :BaseRepo<Customer, SSEContext>
    {
        public CustomerRepo(SSEContext dbcontext) : base(dbcontext)
        {

        }
    }
}
