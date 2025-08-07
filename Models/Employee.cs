using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
