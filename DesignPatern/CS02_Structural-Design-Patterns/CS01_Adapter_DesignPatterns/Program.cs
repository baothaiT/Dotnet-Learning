
using CS01_Adapter_DesignPatterns.Services;
using CS01_Adapter_DesignPatterns.Services.Interface;

namespace CS01_Adapter_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Old system working with XML
        XmlDataProvider xmlDataProvider = new XmlDataProvider();

        // New system expects JSON, so we use the adapter
        IJsonDataProvider jsonDataProvider = new XmlToJsonAdapter(xmlDataProvider);

        // Get the data in JSON format
        string jsonData = jsonDataProvider.GetJsonData();

        // Output the JSON data
        Console.WriteLine("JSON Data: \n" + jsonData);
    }
}