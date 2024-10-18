using CS02_Builder_DesignPattern.Models;
using CS02_Builder_DesignPattern.Sevices.Builder;

namespace CS02_Builder_DesignPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        PersonModel personModel = new PersonModelBuilder()
            .AddId("IdTest")
            .AddEmail("EmailTest")
            .AddName("NameTest")
            .AddPhone("PhoneTest")
            .Build();

        Console.WriteLine(personModel.ToString());
    }
}