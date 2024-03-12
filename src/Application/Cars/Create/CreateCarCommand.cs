using ErrorOr;
using MediatR;

namespace Application.Cars.Create;

public record CreateCarCommand(
    string Plate,
    string Model,
    string Color,
    string Brand,
    string Country,
    string Line1,
    string Line2,
    string City,
    string State,
    string ZipCode) : IRequest<ErrorOr<Unit>>;