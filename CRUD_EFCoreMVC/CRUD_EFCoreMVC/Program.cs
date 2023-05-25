using BusinessLogicLayer.IRepo;
using BusinessLogicLayer.Repo;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IServices;
using ServiceLayer.Service;

namespace CRUD_EFCoreMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();                    //connection, b => b.MigrationsAssembly("CRUD_EFCoreMVC")
            builder.Services.AddDbContext<DataManager>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("DataManager"), b => b.MigrationsAssembly("CRUD_EFCoreMVC")));

            builder.Services.AddControllers();

            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}