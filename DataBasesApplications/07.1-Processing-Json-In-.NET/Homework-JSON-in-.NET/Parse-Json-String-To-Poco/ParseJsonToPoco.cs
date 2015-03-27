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


namespace Parse_Json_String_To_Poco
{
    class ParseJsonToPoco
    {
        static void Main()
        {
            var jsonText = File.ReadAllText(SolutionPaths.OutputFolder + "softuniNews.json");
            var jsonObject = JObject.Parse(jsonText)["rss"]["channel"]["item"];
            RssItem template = new RssItem();
            var items = new List<RssItem>();

            jsonObject.ToList()
                .ForEach(j => 
                    items.Add(JsonConvert.DeserializeAnonymousType(j.ToString(), template)));

            StringBuilder htmlItems = new StringBuilder();
            htmlItems.Append(HtmlCreate.InitialDoctype());
            htmlItems.Append(HtmlCreate.Body(items));
            htmlItems.Append(HtmlCreate.EndDoctype());

            File.WriteAllText(SolutionPaths.OutputFolder + "RssHtml.html", htmlItems.ToString());
        }
    }

    class RssItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public RssItem()
        {

        }
    }

    class HtmlCreate
    {
        public static string Body(List<RssItem> inputList)
        {
            StringBuilder result = new StringBuilder();

            inputList.ForEach(i => result.Append(string.Format(
                HtmlCreate.Element("div", "",
                    HtmlCreate.Element("h3", " style=\"margin-top: 50px;\"", i.Title) +
                    HtmlCreate.Element("a", " href=" + "\"" + i.Link + "\"", i.Link) +
                    i.Description)
                )));

            return result.ToString();
        }
        public static string Element(string tag, string atribute, string content)
        {
            string result = "<" + tag + atribute + ">\n" + content + "\n</" + tag + ">\n";
            return result;
        }

        public static string InitialDoctype()
        {
            string result = "<!doctype html><html><head><meta charset=\"utf-8\"></head><body>";
            return result;
        }

        public static string EndDoctype()
        {
            string result = "</body></html>";
            return result;
        }
    }
}
