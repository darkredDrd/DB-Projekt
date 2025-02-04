using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Marks;

public class GetMarkQueryQueryHandler : IRequestHandler<GetMarkQuery, Hall>
{
    private readonly UniversityContext context;

    public GetMarkQueryQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<Hall> Handle(GetMarkQuery request, CancellationToken cancellationToken)
    {
        var mark = await context.Marks
            .Include(mark => mark.Course)
            .Include(mark => mark.Teacher)
            .Include(mark => mark.Student)
            .FirstOrDefaultAsync(mark => mark.Id == request.Id, cancellationToken);

        return mark;
    }
}