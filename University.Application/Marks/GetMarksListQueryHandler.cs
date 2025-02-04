using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Marks;

public class GetMarksListQueryHandler : IRequestHandler<GetMarksListQuery, List<Hall>>
{
    private readonly UniversityContext context;

    public GetMarksListQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<List<Hall>> Handle(GetMarksListQuery request, CancellationToken cancellationToken)
    {
        var marks = await context.Marks
            .Include(mark => mark.Course)
            .Include(mark => mark.Teacher)
            .Include(mark => mark.Student)
            .ToListAsync(cancellationToken);

        return marks;
    }
}