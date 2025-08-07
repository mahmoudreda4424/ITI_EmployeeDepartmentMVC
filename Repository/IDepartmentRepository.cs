using Lab10.Models;

namespace Lab10.Repository
{
    public interface IDepartmentRepository
    {
        Task Add(Department department);

        Task Delete(int id);

        Task Update(Department department, int id);

        Task<Department> GetById(int id);

        Task<List<Department>> GetAll();

        Task<List<Employee>> GetEmployeesByDepartment(int departmentId);
    }
}
