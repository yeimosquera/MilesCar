using Domain.Cars;
using Domain.RentCars;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class RentCarConfiguration : IEntityTypeConfiguration<RentCar>
{
    public void Configure(EntityTypeBuilder<RentCar> builder)
    {
        builder.ToTable("RentCar");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            carId => carId.Value,
            value => new CarId(value));

        builder.Property(c => c.Plate).HasMaxLength(50);

        builder.Property(c => c.Model).HasMaxLength(50);

        builder.Property(c => c.Color).HasMaxLength(50);

        builder.Property(c => c.Brand).HasMaxLength(50);

        builder.OwnsOne(c => c.AddressCollection, addressBuilder => {

            addressBuilder.Property(a => a.Country).HasMaxLength(30);

            addressBuilder.Property(a => a.Line1).HasMaxLength(20);

            addressBuilder.Property(a => a.Line2).HasMaxLength(20).IsRequired(false);

            addressBuilder.Property(a => a.City).HasMaxLength(40);

            addressBuilder.Property(a => a.State).HasMaxLength(40);

            addressBuilder.Property(a => a.ZipCode).HasMaxLength(10).IsRequired(false);
        });
            builder.OwnsOne(c => c.AddressDelivery, addressBuilder => {

            addressBuilder.Property(a => a.Country).HasMaxLength(30);

            addressBuilder.Property(a => a.Line1).HasMaxLength(20);

            addressBuilder.Property(a => a.Line2).HasMaxLength(20).IsRequired(false);

            addressBuilder.Property(a => a.City).HasMaxLength(40);

            addressBuilder.Property(a => a.State).HasMaxLength(40);

            addressBuilder.Property(a => a.ZipCode).HasMaxLength(10).IsRequired(false);
        });
    }
}
