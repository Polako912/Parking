using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Parking.Application.Commands.ParkVehicleCommand;
using Parking.Application.Interfaces;

namespace Parking.Application.Queries.GetParkingSpacesQuery;

public class GetParkingSpacesQueryHandler(IParkingRepository parkingRepository, ILogger<ParkVehicleCommandHandler> logger) : IRequestHandler<GetParkingSpacesQuery, GetParkingSpacesResponse>
{
    public Task<GetParkingSpacesResponse> Handle(GetParkingSpacesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parkingSpaces = parkingRepository.GetParkingSpaces();
            
            var occupiedSpaces = parkingSpaces.Count(x => x.IsOccupied);
            var freeSpaces = parkingSpaces.Count(x => !x.IsOccupied);

            return Task.FromResult(new GetParkingSpacesResponse
            {
                AvailableSpaces = freeSpaces,
                OccupiedSpaces = occupiedSpaces
            });
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occured");
            throw;
        }
    }
}