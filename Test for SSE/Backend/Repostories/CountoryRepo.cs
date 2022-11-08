using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repostories
{
    public class CountoryRepo : BaseRepo<Country, SSEContext>
    {
        public CountoryRepo(SSEContext dbcontext) : base(dbcontext)
        {
        }
    }
}
