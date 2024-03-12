using Domain.Cars;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            carId => carId.Value,
            value => new CarId(value));

        builder.Property(c => c.Plate).HasMaxLength(50);

        builder.Property(c => c.Model).HasMaxLength(50);

        builder.Property(c => c.Color).HasMaxLength(50);

        builder.Property(c => c.Brand).HasMaxLength(50);

        builder.OwnsOne(c => c.Address, addressBuilder => {

            addressBuilder.Property(a => a.Country).HasMaxLength(30);

            addressBuilder.Property(a => a.Line1).HasMaxLength(20);

            addressBuilder.Property(a => a.Line2).HasMaxLength(20).IsRequired(false);

            addressBuilder.Property(a => a.City).HasMaxLength(40);

            addressBuilder.Property(a => a.State).HasMaxLength(40);

            addressBuilder.Property(a => a.ZipCode).HasMaxLength(10).IsRequired(false);
        });
    }
}
