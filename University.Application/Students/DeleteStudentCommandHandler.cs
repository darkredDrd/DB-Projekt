using MediatR;

using University.Persistence;

namespace University.Application.Students;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
{
    private readonly UniversityContext context;

    public DeleteStudentCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await context.Students.FindAsync(request.Id, cancellationToken);
        if (student != null)
        {
            context.Students.Remove(student);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}