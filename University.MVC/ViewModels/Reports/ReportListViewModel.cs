using University.Models;

namespace University.MVC.ViewModels.Reports
{
    public class ReportListViewModel
    {
        public DateTime GeneratedDate { get; set; }

        public List<StudentReportViewModel> Students { get; set; }

        public static ReportListViewModel FromReport(Report report)
        {
            return new ReportListViewModel
            {
                GeneratedDate = report.GeneratedDate,
                Students = report.Students.Select(StudentReportViewModel.FromStudent).ToList()
            };
        }

    }
}
