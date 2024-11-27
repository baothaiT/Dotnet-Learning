namespace CS034_Duplicate_In_Array.Services.HasSet;

public class ExampleWithCustomClass
{
    public ExampleWithCustomClass()
    {

    }

    public void Example()
    {
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 25 },
            new Person { Name = "Alice", Age = 30 }, // Duplicate
            new Person { Name = "Alice", Age = 33 }
        };

        // Use Distinct to remove duplicates
        List<Person> uniquePeople = people.Distinct().ToList();

        Console.WriteLine("ExampleWith Custom Class Case (0)");
        foreach (var person in uniquePeople)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }

        // Use Distinct to remove duplicates
        // Distinct by Name using GroupBy
        var distinctPeople = people
            .GroupBy(p => p.Name)
            .Select(group => group.First()) // Keep the first occurrence
            .ToList();
        Console.WriteLine("ExampleWith Custom Class Case (1)");
        foreach (var person in distinctPeople)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }
    }
}