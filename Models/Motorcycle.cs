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