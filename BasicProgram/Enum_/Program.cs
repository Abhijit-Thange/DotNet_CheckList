using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum_
{
    internal class Program
    {
        enum InsideClass
        {
            January,
            March=3,
            April
        }
        static void Main(string[] args)
        {
            Test r = Test.third;
            Console.WriteLine((int)Test.eight);
            Console.WriteLine(InsideClass.April);
            Console.ReadLine();
        }
    }

    enum Test
    {
        first=1, 
        second=2,
        third=3,
        seven=7,
        eight
    }

}
