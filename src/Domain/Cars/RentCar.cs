using Domain.Cars;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.RentCars;

public sealed class RentCar : AggregateRoot
{
    public RentCar(CarId id, string plate, string model, string color, string brand, Address addresscollection, Address addressDelivery)
    {
        Id = id;
        Plate = plate;
        Model = model;
        Color = color;
        Brand = brand;
        AddressCollection = addresscollection;
        AddressDelivery = addressDelivery;
    }

    private RentCar()
    {

    }

    public CarId Id { get; private set; }
    public string Plate { get; private set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Color { get; private set; } = string.Empty;
    public string Brand { get; private set; } = string.Empty;
    public Address AddressCollection { get; private set; }
    public Address AddressDelivery { get; private set; }

    public static RentCar UpdateCar(Guid id, string plate, string model, string color, string brand, Address addresscollection, Address addressDelivery)
    {
        return new RentCar(new CarId(id), plate, model, color, brand, addresscollection, addressDelivery);
    }
}