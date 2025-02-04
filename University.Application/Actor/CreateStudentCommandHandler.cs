using MediatR;
using University.Persistence;

namespace Cinema.Application.Actor;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
{
    private readonly UniversityContext context;

    public CreateStudentCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = request.ToStudent();

        context.Add(student);

        await context.SaveChangesAsync(cancellationToken);
    }
}