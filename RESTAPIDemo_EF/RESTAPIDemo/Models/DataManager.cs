using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RESTAPIDemo.Models
{
    public class DataManager:DbContext
    {
        public DataManager() : base("WebAppCon")
        { }

        public DbSet<Category> Categories { get; set; }
    }
}