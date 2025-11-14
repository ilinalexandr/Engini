using Company.Application.Models;
using Company.Application.Services.Interfaces;
using Company.Infrastructure.Repositories.Interfaces;
using Company.Model.Entities;

namespace Company.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeDto? GetEmployeeHierarchy(int id)
        {
            var employeeList = _employeeRepository.GetEmployeeHierarchyFlat(id);
            var employeeDtos = employeeList.Select(MapToDto).ToList();

            BuildHierarchy(employeeDtos);

            var result = employeeDtos.FirstOrDefault(x => x.Id == id);
            return result;
        }

        private void BuildHierarchy(List<EmployeeDto> employeeDtos)
        {
            var dict = employeeDtos.ToDictionary(x => x.Id);

            foreach (var dto in dict.Values)
            {
                if (dto.ManagerId != null && dict.ContainsKey((int)dto.ManagerId))
                {
                    var manager = dict[(int)dto.ManagerId];
                    manager.Subordinates.Add(dto);
                }
            }
        }

        private EmployeeDto MapToDto(EmployeeEntity entity)
        {
            return new EmployeeDto
            {
                Id = entity.Id,
                Name = entity.Name,
                ManagerId = entity.ManagerId,
            };
        }
    }
}
