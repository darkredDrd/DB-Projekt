using University.Models;

namespace University.MVC.ViewModels.Students;

public class StudentListViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public static StudentListViewModel FromStudent(Student student)
    {
        var studentListViewModel = new StudentListViewModel
        {
            Id = student.Id,
            Email = student.Email,
            Phone = student.Phone,
            FullName = $"{student.FirstName} {student.LastName}"
        };

        return studentListViewModel;
    }
}