# Question 1

```cs
namespace DotNetExampleCode.Services;

internal class IntegerDivisionService
{
    /// <summary>
    /// Prints all even numbers to the console between 2 and the highest parameter value (inclusive)
    /// which is EVENLY divisible by the lowest parameter value.
    /// This will be printed wiht comma delimiters and sorted by lower -> higher numbers
    /// </summary>
    private void PrintEvenNumbers(int int1, int int2)
    {
        // Check for integers that are out of bounds.
        if (int1 < 2 || int2 < 2)
        {
            // Would ideally throw an error here, but that was not part of the instructions.
        }

        var higherValue = Math.Max(int1, int2);
        var lowerValue = Math.Min(int1, int2);

        List<int> evenlyDivisibleNumbers = [];

        for (var i = higherValue; i >= lowerValue; i--)
        {
            // Skip if not even
            if (i % 2 != 0)
            {
                continue;
            }

            if (i % lowerValue == 0)
            {
                // Use insert, so that the lower numbers are at the beginning of the list
                evenlyDivisibleNumbers.Insert(index: 0, i);
            }
        }

        Console.WriteLine(string.Join(", ", evenlyDivisibleNumbers));
    }
}
```

# Question 2

## Models

```cs
namespace DotNetExampleCode.Models;

/// <summary>
/// Represents any type of vehicle.
/// </summary>
public abstract class Vehicle
{
    public required string Make;
    public required string Model;
    public required int NumWheels;
    public required double Length;
    public required double Weight;
    public required int MaxPassengers;
}
```

```cs
namespace DotNetExampleCode.Models;

public abstract class SmallOrMediumVehicle : Vehicle { }
```

```cs
namespace DotNetExampleCode.Models;

public class Car : SmallOrMediumVehicle
{
    public Car(string make, string model, double length, double weight, int maxPassengers = 4)
    {
        NumWheels = 4;
        Make = make;
        Model = model;
        Length = length;
        Weight = weight;
        MaxPassengers = maxPassengers;
    }
}
```

```cs
namespace DotNetExampleCode.Models;

public class MotorCycle : SmallOrMediumVehicle
{
    public MotorCycle(string make, string model, double length, double weight, int maxPassengers = 2)
    {
        NumWheels = 2;
        Make = make;
        Model = model;
        Length = length;
        Weight = weight;
        MaxPassengers = maxPassengers;
    }
}
```

```cs
namespace DotNetExampleCode.Models;

public class Bus : Vehicle
{
    public Bus(string make, string model, double length, double weight, int maxPassengers = 20)
    {
        // Perhaps num wheels could be more than 4.
        NumWheels = 4;
        Make = make;
        Model = model;
        Length = length;
        Weight = weight;
        MaxPassengers = maxPassengers;
    }
}
```

## Services

```cs
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
```

```cs
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

        if (_compactOnlyVehicles.Count < _compactOnlySpots && vehicle.Weight < 1500)
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
```
