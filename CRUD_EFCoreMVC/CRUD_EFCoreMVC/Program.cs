using BusinessLogicLayer.IRepo;
using BusinessLogicLayer.Repo;
using CRUD_EFCoreMVC.Middleware;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.IServices;
using ServiceLayer.Service;
using System.Text;

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

            //    builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DataManager>()
            //      .AddDefaultTokenProviders();

            /* builder.Services.AddIdentityCore<IdentityUser>(option=>option.SignIn.RequireConfirmedAccount=true)
                 .AddEntityFrameworkStores<DataManager>();

             builder.Services.AddControllers();
             builder.Services.AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
             })
               .AddJwtBearer(option =>
               {
                   option.SaveToken = true;
                   option.RequireHttpsMetadata = true;
                   option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                   {
                       ValidateAudience = true,
                       ValidateIssuer = true,
                       ValidAudience = builder.Configuration["Jwt:ValidAudiance"],
                       ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
                       ValidateLifetime = true

                   };
               });
 */
            builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
     .AddEntityFrameworkStores<DataManager>();

         //   builder.Services.AddControllers();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
                        ValidateLifetime = true
                    };
                });

            builder.Services.AddAuthorization();

            // Configure cookie options
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            // Configure the default authorization policy
            builder.Services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });


            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();

            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IProductRepo, ProductRepo>();

            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IAccountRepo, AccountRepo>();


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
            app.UseMiddleware<JwtUnauthorizedMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}