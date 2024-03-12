namespace Cars.Common;

public record GetRentResponse(
Guid Id,
string Plate,
string Model,
string Color,
string Brand,
AddressCollectionResponse AddressCollection,
AddressDeliveryResponse AddressDelivery);

public record AddressCollectionResponse(
    string Country,
    string Line1,
    string Line2,
    string City,
    string State,
    string ZipCode);

public record AddressDeliveryResponse(
    string Country,
    string Line1,
    string Line2,
    string City,
    string State,
    string ZipCode);