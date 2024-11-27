namespace CS034_Duplicate_In_Array.Services.HasSet;

public class ExampleWithCustomCollections
{
    public ExampleWithCustomCollections()
    {

    }

    public void Example()
    {
        // Example list with duplicates
        List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6, 1 };

        // Remove duplicates manually
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    numbers.RemoveAt(j);
                    j--; // Adjust index after removal
                }
            }
        }

        // Print the updated list
        Console.WriteLine("ExampleWith Custom Collections");
        Console.WriteLine(string.Join(", ", numbers));
    }
}