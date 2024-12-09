using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Persistence;

namespace University.Application.Courses
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly UniversityContext context;

        public UpdateCourseCommandHandler(UniversityContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var existingCourse = await context.Courses
                .Include(course => course.Students).Include(course => course.Teachers)
                .FirstOrDefaultAsync(course => course.Id == request.Id, cancellationToken);

            existingCourse.Topic = request.Topic;
            existingCourse.NumberOfHours = request.NumberOfHours;
            existingCourse.StartDate = request.StartDate;
            existingCourse.EndDate = request.EndDate;

            foreach (var studentAssignment in request.StudentAssignments)
            {
                var existingStudentInACourse = existingCourse.Students.FirstOrDefault(student => student.Id == studentAssignment.AssigneeId);
                if (existingStudentInACourse == null && studentAssignment.Assigned)
                {
                    // Add a student to a course
                    var newStudent = await context.Students.FirstOrDefaultAsync(student => student.Id == studentAssignment.AssigneeId, cancellationToken);
                    existingCourse.Students.Add(newStudent);
                }

                if (existingStudentInACourse != null && !studentAssignment.Assigned)
                {
                    // Remove a student from a course
                    existingCourse.Students.Remove(existingStudentInACourse);
                }
            }

            foreach (var teacherAssignment in request.TeacherAssignments)
            {
                var existingTeacherInACourse = existingCourse.Teachers.FirstOrDefault(teacher => teacher.Id == teacherAssignment.AssigneeId);

                if (existingTeacherInACourse == null && teacherAssignment.Assigned)
                {
                    // Add a teacher to a course
                    var newTeacher = await context.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == teacherAssignment.AssigneeId, cancellationToken);
                    existingCourse.Teachers.Add(newTeacher);
                }

                if (existingTeacherInACourse != null && !teacherAssignment.Assigned)
                {
                    // Remove a teacher from a course
                    existingCourse.Teachers.Remove(existingTeacherInACourse);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
