using SampleMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleMVCApp.DAL
{
    public class DataAccess :DbContext
    {
        public DataAccess() :base("WebAppCon")
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}