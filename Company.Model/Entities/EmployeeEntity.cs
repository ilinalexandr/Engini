namespace Company.Model.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public EmployeeEntity Manager { get; set; }

        public EmployeeEntity() { }
    }
}
