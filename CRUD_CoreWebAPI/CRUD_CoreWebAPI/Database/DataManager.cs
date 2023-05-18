using CRUD_CoreWebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CoreWebAPI.Database
{
    public class DataManager:IdentityDbContext<User>
    {
        public DataManager(DbContextOptions<DataManager> options) : base(options) { }
         

        public DbSet<Category> categories { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<User> users { get; set; }

    }
}
