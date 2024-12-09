using MediatR;

using University.Persistence;

namespace University.Application.Teachers;

public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
{
    private readonly UniversityContext context;

    public DeleteTeacherCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await context.Teachers.FindAsync(request.Id, cancellationToken);
        if (teacher != null)
        {
            context.Teachers.Remove(teacher);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}