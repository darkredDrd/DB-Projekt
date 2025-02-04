using MediatR;
using University.Models;

namespace Cinema.Application.Actor;

public class GetStudentQuery : IRequest<Revenue>
{
    public int Id { get; set; }
}