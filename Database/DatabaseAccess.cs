using Magazyn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Magazyn.Database
{
    public class DatabaseAccess : DbContext
    {
        public DatabaseAccess() : base("connectionString")
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
    }
}