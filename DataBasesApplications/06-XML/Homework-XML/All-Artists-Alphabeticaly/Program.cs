using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace All_Artists_Alphabeticaly
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\\..\\..\\\Create-XML-Catalog\catalog.xml");
            var rootNodes = doc.SelectNodes("/music/artist");
            SortedSet<string> artistNames = new SortedSet<string>() { };

            foreach (XmlElement node in rootNodes)
            {
                artistNames.Add(node.Attributes["name"].Value);
            }

            foreach (var name in artistNames)
            {
                Console.WriteLine(name);
            }           
        }
    }
}
