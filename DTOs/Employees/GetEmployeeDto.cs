namespace API1.DTOs.Employees
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int DepartmentId { get; set; }

    }
}
