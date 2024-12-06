using University.Models;

namespace University.MVC.Models.Teachers;

public class TeacherDetailsViewModel
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string PassportNumber { get; set; }

    public DateTime? Birthday { get; set; }

    public static TeacherDetailsViewModel FromTeacher(Teacher teacher)
    {
        var teacherDetailsViewModel = new TeacherDetailsViewModel()
        {
            Id = teacher.Id,
            PassportNumber = teacher.PassportNumber,
            Email = teacher.Email,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Phone = teacher.Phone,
            Birthday = teacher.Birthday
        };

        return teacherDetailsViewModel;
    }
}