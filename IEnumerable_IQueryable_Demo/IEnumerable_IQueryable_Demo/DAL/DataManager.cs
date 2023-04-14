using IEnumerable_IQueryable_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IEnumerable_IQueryable_Demo.DAL
{
    public class DataManager:DbContext
    {
        public DataManager():base("WebAppCon")
        {

        }
        public virtual DbSet<Student> Students { get; set; }
    }
}