using Cars.Common;
using Domain.Cars;
using ErrorOr;
using MediatR;
using System.Reflection.Emit;

namespace Application.Cars.GetByZipCode;


internal sealed class GetByZipCodeQueryHandler : IRequestHandler<GetByZipCodeQuery, ErrorOr<IReadOnlyList<CarResponse>>>
{
    private readonly ICarRepository _carRepository;

    public GetByZipCodeQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<CarResponse>>> Handle(GetByZipCodeQuery query, CancellationToken cancellationToken)
    {
        
        IReadOnlyList<Car> carws = await _carRepository.GetByZipCodeAsync(query.ZipCode);

        return carws.Select(car => new CarResponse(
                car.Id.Value,
                car.Plate,
                car.Model,
                car.Color,
                car.Brand,
                new AddressResponse(car.Address.Country,
                    car.Address.Line1,
                    car.Address.Line2,
                    car.Address.City,
                    car.Address.State,
                    car.Address.ZipCode)
            )).ToList();

    }
}