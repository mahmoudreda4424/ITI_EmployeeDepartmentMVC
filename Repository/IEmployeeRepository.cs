using Lab10.Models;

namespace Lab10.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();

        Task<Employee> GetById(int id);

        Task Add(Employee entity);

        Task Update(Employee entity, int id);

        Task Delete(int id);
    }
}
