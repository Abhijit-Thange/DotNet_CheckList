using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cookies=new HttpCookies();
            cookies["name"] = "Abhi";
            cookies["sname"] = "Thange";
            Console.WriteLine(cookies["sname"]);
            Console.ReadLine();
        }
    }
}
