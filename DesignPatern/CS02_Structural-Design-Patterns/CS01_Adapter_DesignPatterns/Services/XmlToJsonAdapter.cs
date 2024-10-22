


using System.Net.Http.Json;
using System.Xml.Linq;
using CS01_Adapter_DesignPatterns.Services.Interface;
using Newtonsoft.Json;

namespace CS01_Adapter_DesignPatterns.Services;

public class XmlToJsonAdapter : IJsonDataProvider
    {
        private readonly XmlDataProvider _xmlDataProvider;

        public XmlToJsonAdapter(XmlDataProvider xmlDataProvider)
        {
            _xmlDataProvider = xmlDataProvider;
        }

        public string GetJsonData()
        {
            // Get XML data from the adaptee
            string xmlData = _xmlDataProvider.GetXmlData();

            // Convert XML data to XDocument
            XDocument xmlDoc = XDocument.Parse(xmlData);

            // Convert the XML to JSON
            string jsonData = JsonConvert.SerializeXNode(xmlDoc, Formatting.Indented);
        
            return jsonData;
        }
    }