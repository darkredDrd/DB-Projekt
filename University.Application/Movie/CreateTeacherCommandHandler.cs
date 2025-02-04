using MediatR;

using University.Persistence;

namespace University.Application.Teachers;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand>
{
    private readonly UniversityContext context;

    public CreateTeacherCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = request.ToTeacher();

        context.Add(teacher);

        await context.SaveChangesAsync(cancellationToken);
    }
}