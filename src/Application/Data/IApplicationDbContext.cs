using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Domain.Cars;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Domain.RentCars;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<Car> Cars { get; set; }
    DbSet<RentCar> RentCars { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

