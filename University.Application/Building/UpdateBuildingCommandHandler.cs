using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Buildings
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand>
    {
        private readonly CinemaContext context;

        public UpdateBuildingCommandHandler(CinemaContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var existingBuilding = await context.Buildings
                //.Include(course => course.Students).Include(course => course.Teachers)
                .FirstOrDefaultAsync(building => building.Id == request.Id, cancellationToken); 

            existingBuilding.Name = request.Name;
            existingBuilding.Address = request.Address;

            //foreach (var studentAssignment in request.StudentAssignments)
            //{
            //    var existingStudentInACourse = existingCourse.Students.FirstOrDefault(student => student.Id == studentAssignment.AssigneeId);
            //    if (existingStudentInACourse == null && studentAssignment.Assigned)
            //    {
            //        // Add a student to a course
            //        var newStudent = await context.Students.FirstOrDefaultAsync(student => student.Id == studentAssignment.AssigneeId, cancellationToken);
            //        existingCourse.Students.Add(newStudent);
            //    }

            //    if (existingStudentInACourse != null && !studentAssignment.Assigned)
            //    {
            //        // Remove a student from a course
            //        existingCourse.Students.Remove(existingStudentInACourse);
            //    }
            //}

            //foreach (var teacherAssignment in request.TeacherAssignments)
            //{
            //    var existingTeacherInACourse = existingCourse.Teachers.FirstOrDefault(teacher => teacher.Id == teacherAssignment.AssigneeId);

            //    if (existingTeacherInACourse == null && teacherAssignment.Assigned)
            //    {
            //        // Add a teacher to a course
            //        var newTeacher = await context.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == teacherAssignment.AssigneeId, cancellationToken);
            //        existingCourse.Teachers.Add(newTeacher);
            //    }

            //    if (existingTeacherInACourse != null && !teacherAssignment.Assigned)
            //    {
            //        // Remove a teacher from a course
            //        existingCourse.Teachers.Remove(existingTeacherInACourse);
            //    }
            //}

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
