using Company.Model.Entities;

namespace Company.Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeeEntity> GetEmployeeHierarchyFlat(int id);
    }
}
