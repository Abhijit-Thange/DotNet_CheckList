using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stringbuilder
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string n = "\"Abhijit\"\nThange";
            string p = @"C\Program\Nimap";
            Console.WriteLine(n+ "     "+p);

            StringBuilder str1 = new StringBuilder("Nimap");

            Console.WriteLine(str1.Capacity);
            Console.WriteLine(str1.MaxCapacity);
            Console.WriteLine(str1.Append("ABC"));
            Console.WriteLine(str1.AppendLine("pqr"));

            Console.WriteLine();

            var program = new Program();

            string str2 = "Good Afternoon";
            str1.Append("Mumbai");
            
            int s = 1234;
           // string s1=s.ToString("x");
            Console.WriteLine(str2);

            Console.WriteLine(str2.IndexOf('A'));
            Console.WriteLine(str2.Last());
           // Console.WriteLine(str2.LastIndexOfAny(str2.ToCharArray()));
           Console.WriteLine(str2.ToUpperInvariant());
            Console.WriteLine(str2.ToUpper());
            
            Console.ReadLine();
        }
    }
}
