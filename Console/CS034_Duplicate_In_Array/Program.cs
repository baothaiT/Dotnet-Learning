

using CS034_Duplicate_In_Array.Services.HasSet;
using CS034_Duplicate_In_Array.Services.Linq;

namespace CS034_Duplicate_In_Array;

 class Program
{
    static void Main(string[] args)
    {
        ExampleWithLinq exampleWithLinq = new ExampleWithLinq();
        exampleWithLinq.Example();

        ExampleWithHasSet exampleWithHasSet = new ExampleWithHasSet();
        exampleWithHasSet.Example();

        ExampleWithCustomCollections exampleWithCustomCollections = new ExampleWithCustomCollections();
        exampleWithCustomCollections.Example();

        ExampleWithCustomClass exampleWithCustomClass = new ExampleWithCustomClass();
        exampleWithCustomClass.Example();
    }
}