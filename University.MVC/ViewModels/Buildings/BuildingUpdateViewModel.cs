using System.ComponentModel.DataAnnotations;

using Cinema.Application.Buildings;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Buildings;

public class BuildingUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Display(Name = "Address")]
    public string Address { get; set; }



    //public List<Checkbox> StudentCheckboxes { get; set; } = new();
    //public List<Checkbox> TeacherCheckboxes { get; set; } = new();

    public UpdateBuildingCommand ToUpdateBuildingCommand()
    {
        var updateBuildingCommand = new UpdateBuildingCommand
        {
            Id = this.Id,
            Name = this.Name,
            Address = this.Address,
        };

        //updateCourseCommand.StudentAssignments = this.StudentCheckboxes.Select(
        //    checkbox => new Assignment
        //    {
        //        Assigned = checkbox.Checked,
        //        AssigneeId = checkbox.Id
        //    }).ToList();

        //updateCourseCommand.TeacherAssignments = this.TeacherCheckboxes.Select(
        //    checkbox => new Assignment
        //    {
        //        Assigned = checkbox.Checked,
        //        AssigneeId = checkbox.Id
        //    }).ToList();

        return updateBuildingCommand;
    }


    public static BuildingUpdateViewModel FromBuilding(Building building, List<Revenue> allStudents, List<Movie> allTeachers) //revenue?
    {
        var buildingUpdateViewModel = new BuildingUpdateViewModel
        {
            Id = building.Id,
            Name = building.Name,
            Address = building.Address,
        };

        //foreach (var student in allStudents)
        //{
        //    var studentCheckbox = new Checkbox
        //    {
        //        Id = student.Id,
        //        Label = $"{student.FirstName} {student.LastName}",
        //        Checked = course.Students.Any(cs => cs.Id == student.Id)
        //    };

        //    courseUpdateViewModel.StudentCheckboxes.Add(studentCheckbox);
        //}

        //foreach (var teacher in allTeachers)
        //{
        //    var teacherCheckbox = new Checkbox
        //    {
        //        Id = teacher.Id,
        //        Label = $"{teacher.FirstName} {teacher.LastName}",
        //        Checked = course.Teachers.Any(cs => cs.Id == teacher.Id)
        //    };

        //    courseUpdateViewModel.TeacherCheckboxes.Add(teacherCheckbox);
        //}

        return buildingUpdateViewModel;
    }
}

//public class Checkbox
//{
//    public int Id { get; set; }
//    public string Label { get; set; }

//    public bool Checked { get; set; }
//}