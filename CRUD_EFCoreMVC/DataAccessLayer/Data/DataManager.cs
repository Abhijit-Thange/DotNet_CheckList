using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class DataManager : DbContext
    {
        public DataManager(DbContextOptions<DataManager> options) : base(options)
        {
            
        }
        public DbSet<Category> categories { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<User> users { get; set; }
    }
}

