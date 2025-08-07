using Lab10.Data;
using Lab10.Models;
using Lab10.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;

namespace Lab10
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // scoped lifetime for DbContext
            builder.Services.AddDbContext<CompanyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

                );
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
            })
             .AddEntityFrameworkStores<CompanyDbContext>()
             .AddDefaultUI();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();





            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CompanyDbContext>();
                dbContext.Database.Migrate();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            

                if (!await userManager.Users.AnyAsync())
                {
                    // Create a default admin user if none exists
                    var adminUser = new IdentityUser { UserName = "www@hotmail.com" };
                    var result = await userManager.CreateAsync(adminUser, "Admin@1");
                }
            }
            app.MapRazorPages();
            app.Run();
        }
    }
}
