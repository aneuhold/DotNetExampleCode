using DotNetExampleCode.Models;

namespace DotNetExampleCode.Services;

public class ParkingLotService
{
    private readonly List<Vehicle> _vehicles = [];

    /// <summary>
    /// The maximum capacity of the parking lot.
    /// </summary>
    private readonly int _maxCapacity;

    public ParkingLotService(int maxCapacity = 100)
    {
        _maxCapacity = maxCapacity;
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        if (_vehicles.Count >= _maxCapacity)
        {
            throw new InvalidOperationException("Parking lot is full.");
        }
        _vehicles.Add(vehicle);
    }
    
    // Add method for removing a vehicle
}