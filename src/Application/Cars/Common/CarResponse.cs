namespace Cars.Common;

public record CarResponse(
Guid Id,
string Plate,
string Model,
string Color,
string Brand,
AddressResponse Address);

public record AddressResponse(
    string Country,
    string Line1,
    string Line2,
    string City,
    string State,
    string ZipCode);