using Cars.Common;
using Customers.Common;
using ErrorOr;
using MediatR;

namespace Application.Cars.GetRentCar;

public record GetRentCarQuery(string plate) : IRequest<ErrorOr<IReadOnlyList<GetRentResponse>>>;