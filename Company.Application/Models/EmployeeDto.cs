namespace Company.Application.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public List<EmployeeDto> Subordinates { get; set; } = new();
    }
}
