using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;
using University.Application.Reports;

namespace Cinema.Application.Screening;

public class CreateScreeningCommandHandler : IRequestHandler<CreateScreeningCommand>
{
    private readonly CinemaContext context;

    public CreateScreeningCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateScreeningCommand request, CancellationToken cancellationToken)
    {
        var screening = await context.Screenings.FirstOrDefaultAsync(s => s.Id == request.ScreeningId, cancellationToken);
        if (screening == null)
        {
            throw new NullReferenceException("Screening not found");
        }

        var screening = new Screening 
        {
            Screening = screening,
            TotalScreening = request.TotalScreening
        };

        context.Add(screening);
        await context.SaveChangesAsync(cancellationToken);
    }
}
