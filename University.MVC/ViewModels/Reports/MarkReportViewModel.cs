using University.Models;

namespace University.MVC.ViewModels.Reports;

public class MarkReportViewModel
{
    public int Score { get; set; }
    public DateTime DateAwarded { get; set; }
    public string TeacherName { get; set; }

    public static MarkReportViewModel FromMark(Mark mark)
    {
        return new MarkReportViewModel
        {
            Score = mark.Score,
            DateAwarded = mark.DateAwarded,
            TeacherName = $"{mark.Teacher.FirstName} {mark.Teacher.LastName}"
        };
    }
}