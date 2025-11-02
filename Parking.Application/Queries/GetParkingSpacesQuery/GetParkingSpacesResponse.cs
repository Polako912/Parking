namespace Parking.Application.Queries.GetParkingSpacesQuery;

public record GetParkingSpacesResponse
{
    public required int AvailableSpaces { get; init; }
    
    public required int OccupiedSpaces { get; init; }
}