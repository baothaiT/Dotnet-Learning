

namespace CS04_Prototype_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS04_Prototype_DesignPatterns!");

        // Original car instance
        CarModel car1 = new CarModel("Tesla Model S", "Red", 762);
        Console.WriteLine("Original Car:");
        car1.ShowDetails();

        // Clone the car using the Prototype pattern
        CarModel car2 = car1.Clone();
        car2.Color = "Blue";  // Modify the color of the cloned car

        Console.WriteLine("\nCloned and Modified Car:");
        car2.ShowDetails();

        // Display original car again to verify it's not affected
        Console.WriteLine("\nOriginal Car after cloning:");
        car1.ShowDetails();
    }
}