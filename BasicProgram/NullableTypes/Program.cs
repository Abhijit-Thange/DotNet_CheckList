using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool n = true;
            bool b = true;
            bool? c = null; // Using nullable we store the null 

            //two of declare nullable variable.
            Nullable<int> x = null;
            int? num = null;

            int a = 10;
            int? m = 20;
            //nullable type need type casting
            //two way of type cast it.
            a = m.Value;
            a = (int)m;
            

            if (a == m)
            {
                Console.WriteLine("a and m are same..");
            }

            Console.ReadLine();
        }
    }
}
