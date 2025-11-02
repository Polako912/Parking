using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Parking.Application.DTOs;
using Parking.Application.Interfaces;
using Parking.Application.Responses;
using Parking.Domain.Enums;
using Parking.Domain.Models;

namespace Parking.Application.Commands.ParkVehicleCommand;

public sealed class ParkVehicleCommandHandler(IParkingRepository parkingRepository, IMapper mapper, ILogger<ParkVehicleCommandHandler> logger)
    : IRequestHandler<ParkVehicleCommand, ParkVehicleResponse>
{
    public async Task<ParkVehicleResponse> Handle(ParkVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var vehicle = Vehicle.Create(request.VehicleReg, (VehicleType)request.VehicleType);

            await parkingRepository.ParkVehicleAsync(vehicle, cancellationToken);
            
            var result = mapper.Map<ParkingRegistryDto>(await parkingRepository.GetParkingRegistryByVehicleAsync(vehicle, cancellationToken));

            return new ParkVehicleResponse
            {
                SpaceNumber = result.ParkingSpace.Number,
                VehicleReg = result.Vehicle.VehicleReg,
                TimeIn = result.TimeIn,
            };
        }
        catch (Exception e)
        {
            logger.LogError(e, "No free spaces available.");
            throw;
        }
    }
}