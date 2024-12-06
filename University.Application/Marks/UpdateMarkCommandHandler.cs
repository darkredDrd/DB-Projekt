using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Persistence;

namespace University.Application.Marks;

public class UpdateMarkCommandHandler : IRequestHandler<UpdateMarkCommand>
{
    private readonly UniversityContext context;

    public UpdateMarkCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateMarkCommand request, CancellationToken cancellationToken)
    {
        var existingMark = await context.Marks
            .Include(mark => mark.Course)
            .Include(mark => mark.Teacher)
            .Include(mark => mark.Student)
            .FirstOrDefaultAsync(mark => mark.Id == request.Id, cancellationToken);

        if (existingMark == null)
        {
            throw new NullReferenceException("Mark not found");
        }

        var course = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);
        if (course == null)
        {
            throw new NullReferenceException("Course not found");
        }

        var teacher = await context.Teachers.FirstOrDefaultAsync(m => m.Id == request.TeacherId, cancellationToken);
        if (teacher == null)
        {
            throw new NullReferenceException("Teacher not found");
        }

        var student = await context.Students.FirstOrDefaultAsync(m => m.Id == request.StudentId, cancellationToken);
        if (student == null)
        {
            throw new NullReferenceException("Student not found");
        }

        existingMark.Score = request.Score;
        existingMark.DateAwarded = request.DateAwarded;
        existingMark.Course = course;
        existingMark.Teacher = teacher;
        existingMark.Student = student;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}