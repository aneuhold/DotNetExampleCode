using DotNetExampleCode.Models;

namespace DotNetExampleCode.Services;

public class ParkingGarageService
{
    private readonly List<SmallOrMediumVehicle> _compactOnlyVehicles = [];
    private readonly List<SmallOrMediumVehicle> _normalVehicles = [];

    private readonly int _compactOnlySpots;
    private readonly int _normalSpots;

    public ParkingGarageService(int compactOnlySpots = 50, int normalSpots = 50)
    {
        _compactOnlySpots = compactOnlySpots;
        _normalSpots = normalSpots;
    }

    public void ParkVehicle(SmallOrMediumVehicle vehicle)
    {
        if (_compactOnlyVehicles.Count >= _compactOnlySpots &&
            _normalVehicles.Count >= _normalSpots)
        {
            throw new InvalidOperationException("Parking garage is full.");
        }

        if (_compactOnlyVehicles.Count < _compactOnlySpots && vehicle.Weight <= 1500)
        {
            // Only allow vehicles that are light enough into compact spots
            _compactOnlyVehicles.Add(vehicle);
            return;
        }

        // Add normal vehicles
        if (_normalVehicles.Count < _normalSpots)
        {
            _normalVehicles.Add(vehicle);
            return;
        }

        // If we got here, then normal vehicle spots are full, and the vehicle will not fit in a compact spot
        throw new InvalidOperationException("Vehicle is too large for a compact spot and all normal spots are full");
    }

    // Add method for removing a vehicle
}