

using System.Xml.Linq;

namespace CS01_Adapter_DesignPatterns.Services;
public class XmlDataProvider
{
    public string GetXmlData()
    {
        XElement xmlData = new XElement("Customer",
                            new XElement("Name", "John Doe"),
                            new XElement("Age", "30"),
                            new XElement("Email", "john.doe@example.com"));

        return xmlData.ToString();
    }
}