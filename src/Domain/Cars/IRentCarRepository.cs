using Domain.Cars;
using Domain.ValueObjects;

namespace Domain.RentCars;

public interface IRentCarRepository
{
    Task<List<RentCar>> GetAll();
    Task<RentCar?> GetByIdAsync(CarId id);
    Task<bool> ExistsAsync(CarId id);
    void Add(RentCar car);
    void Update(RentCar car);
    void Delete(RentCar car);
    Task<List<RentCar>> GetByZipCodeAsync(string zipcode);
}