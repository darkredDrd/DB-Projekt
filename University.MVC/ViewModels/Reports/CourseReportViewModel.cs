using University.Models;

namespace University.MVC.ViewModels.Reports;

public class CourseReportViewModel
{
    public string Topic { get; set; }
    public int TotalScore { get; set; }

    public List<MarkReportViewModel> Marks { get; set; }

    public static CourseReportViewModel FromCourse(Student student, Course course)
    {
        return new CourseReportViewModel
        {
            Topic = course.Topic,
            TotalScore = course.Marks.Sum(m => m.Score),
            Marks = student.Marks.Where(mark => course.Marks.Select(m => m.Id).Contains(mark.Id)).Select(MarkReportViewModel.FromMark).ToList()
        };
    }
}