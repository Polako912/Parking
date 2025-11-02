using AutoMapper;
using Parking.Application.DTOs;
using Parking.Domain.Models;

namespace Parking.Application.Profiles;

public class ParkingSpaceProfile : Profile
{
    public ParkingSpaceProfile()
    {
        CreateMap<ParkingSpace, ParkingSpaceDto>().ReverseMap();
    }
}