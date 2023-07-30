using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace CustomFiltersDemo.Models
{
    public class DataManager : DbContext
    {
        public DataManager() :base("WebAppCon")
        { }

        public DbSet<User> Users { get; set; }
    }
}