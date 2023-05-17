using System;
namespace Services.DTOs.Employee
{
	public class EmployeeEditDto
	{
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}