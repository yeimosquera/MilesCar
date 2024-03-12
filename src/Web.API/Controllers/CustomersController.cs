using Application.Customers.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Application.Customers.GetAll;
using Application.Customers.GetById;
using Swashbuckle.AspNetCore.Annotations;


namespace Web.API.Controllers;


[Route("Customers")]
public class Customers : ApiController
{
    private readonly ISender _mediator;

    public Customers(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Crea un cliente
    /// </summary>
    /// <returns>Se creó un nuevo cliente</returns>
    /// <remarks>
    /// Solicitud de muestra:
    ///
    ///     POST
    ///     {
    ///         "name": "YEISON",
    ///         "lastName": "HINESTROZA MOSQUERA",
    ///         "email": "YEIMOSQUERA1995@GMAIL.COM",
    ///         "phoneNumber": "3116603530",
    ///         "country": "COLOMBIA",
    ///         "line1": "BARRIO EL POBLADO",
    ///         "line2": "EL PARQUE",
    ///         "city": "MEDELLIN",
    ///         "state": "ANTIOQUIA",
    ///         "zipCode": "05001"
    ///     }
    ///
    /// </remarks>
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            customerId => Ok(customerId),
            errors => Problem(errors)
        );
    }

    /// <summary>
    /// Obtiene todos los clientes
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var customersResult = await _mediator.Send(new GetAllCustomersQuery());

        return customersResult.Match(
            customers => Ok(customers),
            errors => Problem(errors)
        );
    }

    /// <summary>
    /// Obtiene un cliente por el Id
    /// </summary>
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var customerResult = await _mediator.Send(new GetCustomerByIdQuery(id));

        return customerResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
        );
    }

    

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
    //{
    //    if (command.Id != id)
    //    {
    //        List<Error> errors = new()
    //        {
    //            Error.Validation("Customer.UpdateInvalid", "The request Id does not match with the url Id.")
    //        };
    //        return Problem(errors);
    //    }

    //    var updateResult = await _mediator.Send(command);

    //    return updateResult.Match(
    //        customerId => NoContent(),
    //        errors => Problem(errors)
    //    );
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    var deleteResult = await _mediator.Send(new DeleteCustomerCommand(id));

    //    return deleteResult.Match(
    //        customerId => NoContent(),
    //        errors => Problem(errors)
    //    );
    //}
}