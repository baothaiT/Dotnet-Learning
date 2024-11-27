namespace CS034_Duplicate_In_Array.Services.HasSet;

public class ExampleWithHasSet
{
    public ExampleWithHasSet()
    {

    }

    public void Example()
    {
        // Example list with duplicates
        List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6, 1 };

        // HashSet to track seen elements
        HashSet<int> seen = new HashSet<int>();
        numbers.RemoveAll(n => !seen.Add(n)); // Remove duplicates

        // Print the updated list
        Console.WriteLine("ExampleWith HasSet");
        Console.WriteLine(string.Join(", ", numbers));
    }
}