using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace XPath_Artists_AlbumCount
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\\..\\..\\\Create-XML-Catalog\catalog.xml");
            var rootNodes = doc.SelectNodes("/music/artist");
            Dictionary<String, int> artistAlbums = new Dictionary<string, int>();

            foreach (XmlElement artistNode in rootNodes)
            {
                var artistName = artistNode.Attributes["name"].Value;
                var albumNumber = artistNode.SelectNodes("album").Count;
                artistAlbums.Add(artistName, albumNumber);
            }

            foreach (var item in artistAlbums)
            {
                Console.WriteLine("Artist Name - {0} , Album Count - {1}", item.Key, item.Value);
            }
        }
    }
}
