using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;
using ErrorOr;
using Domain.Cars;

namespace Application.Cars.Create;

public sealed class RentCarCommandHandler : IRequestHandler<CreateCarCommand, ErrorOr<Unit>>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RentCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(CreateCarCommand command, CancellationToken cancellationToken)
    {
        try
        {   
            if (Address.Create(command.Country, command.Line1, command.Line2, command.City,
                        command.State, command.ZipCode) is not Address address)
            {
                return Error.Validation("Error de direccion");
            }

            var car = new Car(
                new CarId(Guid.NewGuid()),
                command.Plate,
                command.Model,
                command.Color,
                command.Brand,
                address
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
