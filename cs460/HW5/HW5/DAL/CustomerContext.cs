using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HW5.Models;

/**
 * Author: Alex Molodyh
 * Date: 11/3/2017
 * Class: CS460
 * Assignment: HWK5
 **/

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