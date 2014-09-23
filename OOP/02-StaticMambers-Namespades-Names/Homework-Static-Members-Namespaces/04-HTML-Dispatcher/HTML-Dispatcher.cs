using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_HTML_Dispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAtribute("id","page");
            div.AddAtribute("class","big");
            div.AddContent("<p>Hello!</p>");
            Console.WriteLine(div*2);
        }
    }
}
