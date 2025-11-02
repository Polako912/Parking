using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Parking.Application.Commands.ParkVehicleCommand;
using Parking.Application.DTOs;
using Parking.Application.Interfaces;
using Parking.Application.Responses;
using Parking.Domain.ValuesObjects;

namespace Parking.Application.Commands.ExitVehicleCommand;

public sealed class ExitVehicleCommandHandler(IParkingRepository parkingRepository, IMapper mapper, ILogger<ParkVehicleCommandHandler> logger) : IRequestHandler<ExitVehicleCommand, ExitVehicleResponse>
{
    public async Task<ExitVehicleResponse> Handle(ExitVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = mapper.Map<ParkingRegistryDto>(await parkingRepository.ExitVehicleAsync(request.VehicleReg, cancellationToken));
            
            var minutesParked = (result.TimeOut - result.TimeIn).Minutes;

            var parkingCharge = ParkingCharges.CalculateParkingCharge(result.Vehicle.VehicleType, minutesParked);

            return new ExitVehicleResponse
            {
                TimeIn = result.TimeIn,
                TimeOut = result.TimeOut,
                VehicleCharge = parkingCharge,
                VehicleReg = result.Vehicle.VehicleReg
            };
        }
        catch (Exception e)
        {
            logger.LogError(e, "Vehicle not found");
            throw;
        }
    }
}