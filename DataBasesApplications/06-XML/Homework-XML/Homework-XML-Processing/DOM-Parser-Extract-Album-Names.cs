using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Homework_XML_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\\..\\..\\\Create-XML-Catalog\catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            XmlNodeList childNodes = rootNode.ChildNodes;

            foreach (XmlNode child in childNodes)
            {
                XmlNodeList nodes = child.ChildNodes;
                Console.WriteLine("Artist : {0}", child.Attributes["name"].Value);
                foreach (XmlElement element in nodes)
                {
                    XmlAttribute atr = element.Attributes["title"];
                    Console.WriteLine("  Album : {0}", atr.Value);
                }
            }
        }
    }
}
