namespace CS034_Duplicate_In_Array.Services.Linq;

public class ExampleWithLinq
{
    public ExampleWithLinq()
    {

    }

    public void Example()
    {
        // Example list with duplicates
        List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6, 1 };

        // Use Distinct to remove duplicates
        List<int> uniqueNumbers = numbers.Distinct().ToList();

        // Print the updated list
        Console.WriteLine("ExampleWith Linq");
        Console.WriteLine(string.Join(", ", uniqueNumbers));
    }
}