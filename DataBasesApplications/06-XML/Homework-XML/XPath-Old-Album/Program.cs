using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace XPath_Old_Album
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument catalog = XDocument.Load(@"..\..\..\Create-XML-Catalog\catalog.xml");

            var albums = catalog.XPathSelectElements("//album");

            foreach (var album in albums)
            {
                string albumPrice = album.Element("price").Attribute("value").Value;
                string albumName = album.Attribute("title").Value;
                DateTime albumDate = DateTime.Parse(album.Attribute("year").Value);
                DateTime fiveYearsAgo = DateTime.Now.AddYears(-5);
                
                if (albumDate <= fiveYearsAgo)
                {
                    Console.WriteLine("Album Title : {0}, Album Price : {1}", albumName, albumPrice);
                }
            }
        }
    }
}
