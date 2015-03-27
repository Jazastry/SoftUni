using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace Cheaper_Albums
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\Create-XML-Catalog\catalog.xml");
            XmlNodeList albumNodes = doc.SelectNodes("/music/artist/album");

            foreach (XmlNode albumNode in albumNodes)
            {
                XmlNode priceNode = albumNode.SelectSingleNode("price");
                var price = double.Parse(priceNode.Attributes["value"].Value);
                if (price > 20)
                {
                    XmlNode parentNode = albumNode.ParentNode.RemoveChild(albumNode);
                }
            }

            doc.Save(@"..\..\cheap-albums-catalog.xml");
        }
    }
}
