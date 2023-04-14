using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInterpolation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = 10;
            int n2 = 20;
            string s=null;
            Console.WriteLine("sum of " + n1 + " and " + n2 + " is " + n1 + n2);

            Console.WriteLine("sum of " + n1 + " and " + n2 + " is " + (n1 + n2));
            s = "sum of " + n1 + " and " + n2 + " is " + (n1 + n2);

            Console.WriteLine("sum of {0" +
                "} and {1} is {2}",n1,n2,n1+n2);
            s = string.Format("sum of {0} and {1} is {2}", n1, n2, n1 + n2);

            Console.WriteLine($"sum of {n1} and {n2} is {n1 + n2}"); //String Interopolation
            s = $"sum of {n1} and {n2} is {n1 + n2}";

            Console.WriteLine(s);
            Console.ReadLine();


        }
    }
}
