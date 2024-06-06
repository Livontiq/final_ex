using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace test5
{
    class Connect : DbContext
    {
        public Connect() : base("DefaultConnection") 
        { }

        public DbSet<Car> Cars { get; set; }   
    }
}
