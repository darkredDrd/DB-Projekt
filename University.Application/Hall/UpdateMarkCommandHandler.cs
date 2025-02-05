﻿using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Marks;

public class UpdateMarkCommandHandler : IRequestHandler<UpdateMarkCommand>
{
    private readonly CinemaContext context;

    public UpdateMarkCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateMarkCommand request, CancellationToken cancellationToken)
    {
        var existingHall = await context.Halls
            .Include(hall => hall.Cinema)
            .FirstOrDefaultAsync(hall => hall.Id == request.Id, cancellationToken);

        if (existingHall == null)
        {
            throw new NullReferenceException("Hall not found");
        }

        var cinema = await context.Cinemas.FirstOrDefaultAsync(c => c.Id == request.CinemaId, cancellationToken);
        if (cinema == null)
        {
            throw new NullReferenceException("Cinema not found");
        }

        existingHall.Name = request.Name;
        existingHall.Seats = request.Seats;
        existingHall.Cinema = cinema;

        await context.SaveChangesAsync(cancellationToken);
    }
}