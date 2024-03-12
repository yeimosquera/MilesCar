using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Cars;

public sealed class Car : AggregateRoot
{
    public Car(CarId id, string plate, string model, string color, string brand, Address address)
    {
        Id = id;
        Plate = plate;
        Model = model;
        Color = color;
        Brand = brand;
        Address = address;       
    }

    private Car()
    {

    }

    public CarId Id { get; private set; }
    public string Plate { get; private set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Color { get; private set; } = string.Empty;
    public string Brand { get; private set; } = string.Empty;
    public Address Address { get; private set; }

    public static Car UpdateCar(Guid id, string plate, string model, string color, string brand, Address address)
    {
        return new Car(new CarId(id), plate, model, color, brand, address);
    }
}