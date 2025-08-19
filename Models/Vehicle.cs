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