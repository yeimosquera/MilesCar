using Domain.RentCars;
using Domain.ValueObjects;

namespace Domain.Cars;

public interface ICarRepository
{
    Task<List<Car>> GetAll();
    Task<Car?> GetByIdAsync(CarId id);
    Task<bool> ExistsAsync(CarId id);
    void Add(Car car);
    void Update(Car car);
    void Delete(Car car);
    Task<List<Car>> GetByZipCodeAsync(string zipcode);
    Task<List<RentCar>> GetRentCarAsync(string plate);
}