using CS04_Prototype_DesignPatterns.Services.Prototype;

namespace CS04_Prototype_DesignPatterns;

public class CarModel
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int HorsePower { get; set; }

    public CarModel(string model, string color, int horsePower)
    {
        Model = model;
        Color = color;
        HorsePower = horsePower;
    }

    // The Clone method will return a shallow copy of the current object
    public CarModel Clone()
    {
        return (CarModel)this.MemberwiseClone();
    }

    // Display the details of the car
    public void ShowDetails()
    {
        Console.WriteLine($"Car Model: {Model}, Color: {Color}, HorsePower: {HorsePower}");
    }
} 