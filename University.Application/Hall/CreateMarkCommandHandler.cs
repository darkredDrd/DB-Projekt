using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Marks;

public class CreateMarkCommandHandler : IRequestHandler<CreateMarkCommand>
{
    private readonly UniversityContext context;

    public CreateMarkCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateMarkCommand request, CancellationToken cancellationToken)
    {
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

        var mark = new Hall
        {
            Score = request.Score,
            DateAwarded = request.DateAwarded,
            Course = course,
            Teacher = teacher,
            Student = student
        };

        context.Add(mark);
        await context.SaveChangesAsync(cancellationToken);
    }
}