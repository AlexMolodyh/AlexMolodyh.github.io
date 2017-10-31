using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HW5.Models;

namespace HW5.DAL
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("name=CustomerDBContext")
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}