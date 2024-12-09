using MediatR;

using University.Persistence;

namespace University.Application.Courses;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
{
    private readonly UniversityContext context;

    public DeleteCourseCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await context.Courses.FindAsync(request.Id, cancellationToken);
        if (course != null)
        {
            context.Courses.Remove(course);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}