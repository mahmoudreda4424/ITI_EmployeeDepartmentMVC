using Lab10.Data;
using Lab10.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lab10.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task Add(Employee employee)
        {
            //if (employee == null)
            //    throw new Exception("Employee Invaild data");

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var exist = await _context.Employees.FindAsync(id);

            if (exist != null)
            {
                _context.Employees.Remove(exist);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("this employee not found in database");
            }
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await _context.Employees.Include(x => x.Department).ToListAsync();

            if (employees == null)
                throw new Exception("There is no one employee");

            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
            var exist = await _context.Employees
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (exist == null)
                throw new Exception("Employee not found");

            return exist;
        }

        public async Task Update(Employee entity, int id)
        {
            var exsit = await GetById(id);

            if (exsit != null)
            {
                exsit.Name = entity.Name;
                exsit.Email = entity.Email;
                exsit.DepartmentId = entity.DepartmentId;

                await _context.SaveChangesAsync();
            }
            else
                throw new Exception("Employee not found");
        }
    }
}
