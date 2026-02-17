using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public StudentProfile StudentProfile { get; set; }

        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }

}
