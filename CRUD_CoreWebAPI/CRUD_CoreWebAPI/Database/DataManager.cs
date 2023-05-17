using CRUD_CoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CoreWebAPI.Database
{
    public class DataManager:DbContext
    {
        public DataManager(DbContextOptions<DataManager> options) : base(options) { }
         

        public DbSet<Category> categories { get; set; }

        public DbSet<Product> products { get; set; }

        // public DbSet<Report> reports { get; set; }

    }
}
