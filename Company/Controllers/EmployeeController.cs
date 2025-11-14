using Company.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebApi.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }

        [HttpGet("{id}")]
        public IActionResult Hierarchy(int id)
        {
            var employee = _employeeService.GetEmployeeHierarchy(id);
            if (employee == null)
                return NotFound($"Employee with id {id} not found");

            return Ok(employee);
        }
    }
}
