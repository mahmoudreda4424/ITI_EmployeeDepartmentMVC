using Lab10.Data;
using Lab10.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lab10.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CompanyDbContext _context;

        public DepartmentRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task Add(Department department)
        {
            if (department == null)
                throw new Exception("department is null");

            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var exsit = await GetById(id);

            if (exsit != null)
            {
                _context.Departments.Remove(exsit);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Department>> GetAll()
        {
            var departments = await _context.Departments.ToListAsync();

            if (departments == null)
                throw new Exception("departments table is empty");

            return departments;
        }

        public async Task<Department> GetById(int id)
        {
            var exist = await _context.Departments.FindAsync(id);

            if (exist == null)
            {
                throw new Exception("Not Found");
            }

            return exist;
        }

        public async Task Update(Department department, int id)
        {
            var exist = await GetById(id);

            if (exist != null)
            {
                exist.Name = department.Name;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            var dept = await _context.Employees
                .Where(x => x.DepartmentId == departmentId)
                .ToListAsync();

            return dept;
        }
    }
}
