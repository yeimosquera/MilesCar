using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;
using ErrorOr;
using Domain.Cars;
using Domain.RentCars;

namespace Application.Cars.RentCar;

public sealed class RentCarCommandHandler : IRequestHandler<RentCarCommand, ErrorOr<Unit>>
{
    private readonly IRentCarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RentCarCommandHandler(IRentCarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(RentCarCommand command, CancellationToken cancellationToken)
    {
        try
        {   
            if (Address.Create(command.CountryCollection, command.Line1Collection, command.Line2Collection, command.CityCollection,
                        command.StateCollection, command.ZipCodeCollection) is not Address addresscollection)
            {
                return Error.Validation("Error de direccion");
            }

            if (Address.Create(command.CountryDelivery, command.Line1Delivery, command.Line2Delivery, command.CityDelivery,
                       command.StateDelivery, command.ZipCodeDelivery) is not Address addressDelivery)
            {
                return Error.Validation("Error de direccion");
            }

            var car = new Domain.RentCars.RentCar(
                new CarId(Guid.NewGuid()),
                command.Plate,
                command.Model,
                command.Color,
                command.Brand,
                addresscollection,
                addressDelivery
            );

            _carRepository.Add(car);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
        catch (Exception ex )
        {
            return Error.Failure("Error no controlado", ex.ToString());
        }
    }
}
