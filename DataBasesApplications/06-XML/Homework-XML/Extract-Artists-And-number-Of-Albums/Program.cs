using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Extract_Artists_And_number_Of_Albums
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\\..\\..\\\Create-XML-Catalog\catalog.xml");
            XmlNode musicNode = doc.DocumentElement;
            XmlNodeList artistNodes = musicNode.ChildNodes;
            Dictionary<string, int> artistAlbums = new Dictionary<string, int>();

            foreach (XmlNode artistNode in artistNodes)
            {
                string artistName = artistNode.Attributes["name"].Value;
                int albumNodesCount = artistNode.ChildNodes.Count;
                artistAlbums.Add(artistName, albumNodesCount);
            }

            foreach (var item in artistAlbums)
            {
                Console.WriteLine("Artist - {0}, Album - {1}", item.Key, item.Value);
            }
        }
    }
}
