using Application.Cars.GetRentCar;
using Cars.Common;
using Domain.Cars;
using ErrorOr;
using MediatR;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;

namespace Application.Cars.GetByZipCode;


internal sealed class GetRentCarQueryHandler : IRequestHandler<GetRentCarQuery, ErrorOr<IReadOnlyList<GetRentResponse>>>
{
    private readonly ICarRepository _carRepository;

    public GetRentCarQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<GetRentResponse>>> Handle(GetRentCarQuery query, CancellationToken cancellationToken)
    {
        
        IReadOnlyList<Domain.RentCars.RentCar> rent = await _carRepository.GetRentCarAsync(query.plate);

        return rent.Select(car => new GetRentResponse(
                car.Id.Value,
                car.Plate,
                car.Model,
                car.Color,
                car.Brand,
            new AddressCollectionResponse(car.AddressCollection.Country,
                    car.AddressCollection.Line1,
                    car.AddressCollection.Line2,
                    car.AddressCollection.City,
                    car.AddressCollection.State,
                    car.AddressCollection.ZipCode),
            new AddressDeliveryResponse(car.AddressDelivery.Country,
                    car.AddressDelivery.Line1,
                    car.AddressDelivery.Line2,
                    car.AddressDelivery.City,
                    car.AddressDelivery.State,
                    car.AddressDelivery.ZipCode)

            )).ToList();

    }
}