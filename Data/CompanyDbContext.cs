using Lab10.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Data
{
    public class CompanyDbContext : IdentityDbContext<IdentityUser>
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options): base(options)
        {

        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
               .HasOne(e => e.Department)
               .WithMany(d => d.Employees)
               .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Models.Department>().HasData(
                new Models.Department { Id = 1, Name = "Finance" },
                new Models.Department { Id = 2, Name = "HR" },
                new Models.Department { Id = 3, Name = "IT" },
                new Models.Department { Id = 4, Name = "CS" }
                
            );

             modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Alice", Email = "alice@gmail.com", DepartmentId = 1 },
                new Employee { Id = 2, Name = "Bob", Email = "bob@gmail.com", DepartmentId = 2 },
                new Employee { Id = 3, Name = "Charlie", Email = "charlie@gmail.com", DepartmentId = 3 },
                new Employee { Id = 4, Name = "Diana", Email = "diana@gmail.com", DepartmentId = 4 },
                new Employee { Id = 5, Name = "Ethan", Email = "ethan@gmail.com", DepartmentId = 2 },
                new Employee { Id = 6, Name = "Fay", Email = "fay@gmail.com", DepartmentId = 4 },
                new Employee { Id = 7, Name = "George", Email = "george@gmail.com", DepartmentId = 1 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
