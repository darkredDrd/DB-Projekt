using MediatR;

using University.Persistence;

namespace University.Application.Students;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly UniversityContext context;

    public UpdateStudentCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = request.ToStudent();

        context.Add(student);

        await context.SaveChangesAsync(cancellationToken);
    }
}