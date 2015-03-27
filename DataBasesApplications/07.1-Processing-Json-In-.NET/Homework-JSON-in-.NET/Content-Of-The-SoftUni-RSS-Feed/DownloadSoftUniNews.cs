using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using Constants;

namespace Content_Of_The_SoftUni_RSS_Feed
{
    class DownloadSoftUniNews
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            client.DownloadFile("https://softuni.bg/Feed/News", SolutionPaths.OutputFolder + "softuniNews.xml");
        }
    }
}
