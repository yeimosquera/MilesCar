using Cars.Common;
using Customers.Common;
using ErrorOr;
using MediatR;

namespace Application.Cars.GetByZipCode;

public record GetByZipCodeQuery(string ZipCode) : IRequest<ErrorOr<IReadOnlyList<CarResponse>>>;