using MediatR;

using University.Persistence;

namespace University.Application.Teachers;

public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand>
{
    private readonly UniversityContext context;

    public UpdateTeacherCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = request.ToTeacher();

        context.Add(teacher);

        await context.SaveChangesAsync(cancellationToken);
    }
}