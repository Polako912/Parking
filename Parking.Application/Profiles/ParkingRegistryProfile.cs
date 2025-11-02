using AutoMapper;
using Parking.Application.DTOs;
using Parking.Domain.Models;

namespace Parking.Application.Profiles;

public class ParkingRegistryProfile : Profile
{
    public ParkingRegistryProfile()
    {
        CreateMap<ParkingRegistry, ParkingRegistryDto>().ReverseMap();
    }
}