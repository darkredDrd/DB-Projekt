using MediatR;

using University.Persistence;

namespace University.Application.Marks;

public class DeleteMarkCommandHandler : IRequestHandler<DeleteMarkCommand>
{
    private readonly UniversityContext context;

    public DeleteMarkCommandHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteMarkCommand request, CancellationToken cancellationToken)
    {
        var mark = await context.Marks.FindAsync(request.Id, cancellationToken);
        if (mark != null)
        {
            context.Marks.Remove(mark);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}