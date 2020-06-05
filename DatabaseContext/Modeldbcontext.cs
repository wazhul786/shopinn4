using shopinn4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shopinn4.Databasecontext
{
    public class Modeldbcontext:DbContext
    {
        public DbSet<admin> adm { get; set; }
        public DbSet<Cart> crt { get; set; }
        public DbSet<Catagory> cat { get; set; }
        public DbSet<Feedback> fdbk { get; set; }
        public DbSet<Orders> odr { get; set; }
        public DbSet<Product> prod { get; set; }
        public DbSet<Registration> reg { get; set; }
        public Modeldbcontext() : base("DefaultConnection") { }
    }
}