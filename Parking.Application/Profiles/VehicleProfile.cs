using AutoMapper;
using Parking.Application.DTOs;
using Parking.Domain.Models;

namespace Parking.Application.Profiles;

public class VehicleProfile : Profile
{
    public VehicleProfile()
    {
        CreateMap<Vehicle, VehicleDto>().ReverseMap();
    }
}