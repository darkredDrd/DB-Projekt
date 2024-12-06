using System.ComponentModel.DataAnnotations;

using University.Models;

namespace University.MVC.Models.Teachers
{
    public class TeacherCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string PassportNumber { get; set; }

        public DateTime? Birthday { get; set; }

        public Teacher ToTeacher()
        {
            var teacher = new Teacher
            {
                PassportNumber = this.PassportNumber,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Phone = this.Phone,
                Birthday = this.Birthday
            };

            return teacher;
        }
    }
}
