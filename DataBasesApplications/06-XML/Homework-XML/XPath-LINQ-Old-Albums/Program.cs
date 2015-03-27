using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

namespace XPath_LINQ_Old_Albums
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument catalog = XDocument.Load(@"..\..\..\Create-XML-Catalog\catalog.xml");

            var albums = catalog.XPathSelectElements("//album");

            var oldAlbums = from a in albums
                            where DateTime.Parse(a.Attribute("year").Value)
                                .AddYears(5) <= DateTime.Now
                            select new 
                            {
                                Title = a.Attribute("title").Value,
                                Price = a.Element("price").Attribute("value").Value 
                            };

            foreach (var album in oldAlbums)
            {
                Console.WriteLine("Album Title : {0}, Album Price : {1}", album.Title, album.Price);                
            }
        }
    }
}
