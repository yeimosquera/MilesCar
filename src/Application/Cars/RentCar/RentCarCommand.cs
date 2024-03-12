using ErrorOr;
using MediatR;

namespace Application.Cars.RentCar;

public record RentCarCommand(
    string Plate,
    string Model,
    string Color,
    string Brand,
    string CountryCollection,
    string Line1Collection,
    string Line2Collection,
    string CityCollection,
    string StateCollection,
    string ZipCodeCollection,
    string CountryDelivery,
    string Line1Delivery,
    string Line2Delivery,
    string CityDelivery,
    string StateDelivery,
    string ZipCodeDelivery) : IRequest<ErrorOr<Unit>>;