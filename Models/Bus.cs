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