using Company.Application.Models;

namespace Company.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto? GetEmployeeHierarchy(int id);
    }
}
