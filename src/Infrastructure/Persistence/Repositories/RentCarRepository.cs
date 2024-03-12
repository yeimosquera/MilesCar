using Domain.Cars;
using Domain.RentCars;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RentCarRepository : IRentCarRepository
{
    private readonly ApplicationDbContext _context;

    public RentCarRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(RentCar car) => _context.RentCars.Add(car);
    public void Delete(RentCar car) => _context.RentCars.Remove(car);
    public void Update(RentCar car) => _context.RentCars.Update(car);
    public async Task<bool> ExistsAsync(CarId id) => await _context.RentCars.AnyAsync(car => car.Id == id);
    public async Task<RentCar?> GetByIdAsync(CarId id) => await _context.RentCars.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<RentCar>> GetAll() => await _context.RentCars.ToListAsync();
    public async Task<List<RentCar>> GetByZipCodeAsync(string zipcode) => await _context.RentCars.Where(c => c.AddressCollection.ZipCode == zipcode).ToListAsync();

    
}