using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Configuration;
using Constants;

namespace Parse_Xml_To_Json
{
    class ParseXmlToJson
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            XmlDocument document = new XmlDocument();
            document.Load(SolutionPaths.OutputFolder + "softuniNews.xml");

            XmlElement root = document.DocumentElement;
            string jsonFromXml = JsonConvert.SerializeXmlNode(root, Newtonsoft.Json.Formatting.Indented);
            // save .json in separate folder for later use
            File.WriteAllText(SolutionPaths.OutputFolder + "softuniNews.json", jsonFromXml);

            var jsonObj = JObject.Parse(jsonFromXml);
            var titles = jsonObj["rss"]["channel"]["item"]
                .Select(i => i["title"])
                .ToList();
            titles.ForEach(t => Console.WriteLine(t));
        }
    }
}
