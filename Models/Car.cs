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