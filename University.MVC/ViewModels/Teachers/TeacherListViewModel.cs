using University.Models;

namespace University.MVC.ViewModels.Teachers;

public class TeacherListViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public static TeacherListViewModel FromTeacher(Teacher teacher)
    {
        var teacherListViewModel = new TeacherListViewModel
        {
            Id = teacher.Id,
            Email = teacher.Email,
            Phone = teacher.Phone,
            FullName = $"{teacher.FirstName} {teacher.LastName}"
        };

        return teacherListViewModel;
    }
}