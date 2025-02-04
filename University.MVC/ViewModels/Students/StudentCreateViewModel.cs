using System.ComponentModel.DataAnnotations;
using Cinema.Application.Actor;
using University.Application.Students;

namespace University.MVC.ViewModels.Students
{
    public class StudentCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Passport number")]
        public string PassportNumber { get; set; }

        public DateTime? Birthday { get; set; }

        public CreateStudentCommand ToCreateStudentCommand()
        {
            var createStudentCommand = new CreateStudentCommand
            {
                PassportNumber = this.PassportNumber,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Phone = this.Phone,
                Birthday = this.Birthday
            };

            return createStudentCommand;
        }
    }
}
