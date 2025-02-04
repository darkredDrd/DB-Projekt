using MediatR;

using Microsoft.Build.Framework;
using Microsoft.Extensions.Caching.Distributed;
using University.Models;
using University.Persistence;

namespace Cinema.Application.Actor;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly UniversityContext context;
    private readonly IDistributedCache cache;

    public UpdateStudentCommandHandler(UniversityContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = request.ToStudent();

        context.Update(student);

        await context.SaveChangesAsync(cancellationToken);

        await InvalidateCache(student);
    }

    private async Task InvalidateCache(Revenue student)
    {
        var key = $"student-{student.Id}";
        await cache.RemoveAsync(key);
    }
}