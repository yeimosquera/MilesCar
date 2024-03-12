using Domain.Cars;
using Domain.RentCars;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Car car) => _context.Cars.Add(car);
    public void Delete(Car car) => _context.Cars.Remove(car);
    public void Update(Car car) => _context.Cars.Update(car);
    public async Task<bool> ExistsAsync(CarId id) => await _context.Cars.AnyAsync(car => car.Id == id);
    public async Task<Car?> GetByIdAsync(CarId id) => await _context.Cars.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Car>> GetAll() => await _context.Cars.ToListAsync();
    public async Task<List<Car>> GetByZipCodeAsync(string zipcode) => await _context.Cars.Where(c => c.Address.ZipCode == zipcode).ToListAsync();
    public async Task<List<RentCar>> GetRentCarAsync(string plate) => await _context.RentCars.Where(c => c.Plate == plate).ToListAsync();
    
}