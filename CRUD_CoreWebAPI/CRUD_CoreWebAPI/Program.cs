using CRUD_CoreWebAPI.Database;
using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using CRUD_CoreWebAPI.Repository.Repo;
using CRUD_CoreWebAPI.Services.IService;
using CRUD_CoreWebAPI.Services.Service;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CoreWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataManager>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataManager")));
            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddTransient<ICategories , Categories>();
            builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IProductRepo, ProductRepo>();
            builder.Services.AddTransient<IReportService, ReportService>();
            builder.Services.AddTransient<IReportRepo, ReportRepo>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline. 
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}