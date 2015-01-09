using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NearEvents.Models
{

    public class DemoContext : DbContext
    {
        public DbSet<Employee> employee { get; set; }
    }
 
}