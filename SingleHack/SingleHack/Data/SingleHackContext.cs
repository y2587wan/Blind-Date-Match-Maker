using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SingleHack.Models
{
    public class SingleHackContext : DbContext
    {
        public SingleHackContext (DbContextOptions<SingleHackContext> options)
            : base(options)
        {
        }

        public DbSet<SingleHack.Models.Person> Person { get; set; }
    }
}
