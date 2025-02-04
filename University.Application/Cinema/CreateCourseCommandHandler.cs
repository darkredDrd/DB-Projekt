using MediatR;

using University.Persistence;

namespace University.Application.Courses;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand>
{
    private readonly UniversityContext context;

    public CreateCourseCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = request.ToCourse();
        context.Courses.Add(course);

        await context.SaveChangesAsync(cancellationToken);
    }
}