using Microsoft.AspNetCore.Mvc;
using MediatR;
using ErrorOr;
using Application.Cars.Create;
using Application.Cars.GetByZipCode;
using Application.Cars.RentCar;
using Application.Cars.GetRentCar;


namespace Web.API.Controllers;


[Route("Cars")]

public class Cars : ApiController
{
    private readonly ISender _mediator;

    public Cars(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Crear un vehículo
    /// </summary>
    /// <returns>Se creó un nuevo vehículo</returns>
    /// <remarks>
    /// Solicitud de muestra:
    ///
    ///     POST
    ///     {
    ///          "plate": "ABC123",
    ///          "model": "2024",
    ///          "color": "AZUL",
    ///          "brand": "Chevrolet",
    ///           "country": "COLOMBIA",
    ///          "line1": "BARRIO EL POBLADO",
    ///          "line2": "EL PARQUE",
    ///          "city": "MEDELLIN",
    ///          "state": "ANTIOQUIA",
    ///          "zipCode": "05001"
    ///        }
    ///
    /// </remarks>    
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateCarCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            carId => Ok(carId),
            errors => Problem(errors)
        );
    }

    /// <summary>
    /// Obtienes los vehiculos de un codigo postal
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetByZipCode/{zipcode}")]
    public async Task<IActionResult> ByZipCode(string zipcode)
    {
        var carResult = await _mediator.Send(new GetByZipCodeQuery(zipcode));

        return carResult.Match(
            car => Ok(car),
            errors => Problem(errors)
        );
    }

    /// <summary>
    /// Crear una solicitud de renta de vehículo
    /// </summary>
    /// <returns>Se creó la solicitud de arrendamiento</returns>
    /// <remarks>
    /// Solicitud de muestra:
    ///
    ///     POST
    ///     {
    ///          "plate": "ABC123",
    ///          "model": "2024",
    ///          "color": "AZUL",
    ///          "brand": "Chevrolet",
    ///          "countryCollection": "Colombia",
    ///          "line1Collection": "Poblado",
    ///          "line2Collection": "Parque",
    ///          "cityCollection": "Medellin",
    ///          "stateCollection": "Antioquia",
    ///          "zipCodeCollection": "005002",
    ///          "countryDelivery": "Colombia",
    ///          "line1Delivery": "Laureles",
    ///          "line2Delivery": "Parque",
    ///          "cityDelivery": "Medellin",
    ///          "stateDelivery": "Antioquia",
    ///          "zipCodeDelivery": "005001"
    ///        }
    ///
    /// </remarks>    
    [HttpPost("RentCar")]
    public async Task<IActionResult> RentCar([FromBody] RentCarCommand command)
    {
        var rentResult = await _mediator.Send(command);

        return rentResult.Match(
            carId => Ok(carId),
            errors => Problem(errors)
        );
    }


    /// <summary>
    /// Obtienes solicitudes de renta por placa
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetRentCar/{plate}")]
    public async Task<IActionResult> GetRentCar(string plate)
    {
        var carResult = await _mediator.Send(new GetRentCarQuery(plate));

        return carResult.Match(
            car => Ok(car),
            errors => Problem(errors)
        );
    }

}