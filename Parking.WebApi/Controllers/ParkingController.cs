using MediatR;
using Microsoft.AspNetCore.Mvc;
using Parking.Application.Commands.ExitVehicleCommand;
using Parking.Application.Commands.ParkVehicleCommand;
using Parking.Application.Queries.GetParkingSpacesQuery;
using Parking.Application.Requests;
using Parking.Application.Responses;

namespace Parking.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ParkVehicleResponse), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ParkVehicleResponse>> ParkVehicleAsync([FromBody] ParkVehicleRequest request, CancellationToken cancellationToken = default)
    {
        var command = ParkVehicleCommand.Create(request.VehicleReg, request.VehicleType);
        var result = await mediator.Send(command, cancellationToken);
        
        return Ok(result);
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GetParkingSpacesResponse[]), StatusCodes.Status200OK, "application/json")]
    public async Task<ActionResult<GetParkingSpacesResponse[]>> GetSpacesAsync(CancellationToken cancellationToken = default)
    {
        var query = new GetParkingSpacesQuery();
        var result = await mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpPost("exit")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ExitVehicleResponse), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExitVehicleResponse>> ExitVehicleAsync([FromBody] string  vehicleReg, CancellationToken cancellationToken = default)
    {
        var command = ExitVehicleCommand.Create(vehicleReg);
        var result = await mediator.Send(command, cancellationToken);
        
        return Ok(result);
    }
}