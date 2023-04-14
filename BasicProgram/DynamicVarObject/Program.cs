using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicVarObject
{
    internal class Program
    {
        // var n = 10; we can not declare var variable globally
        object o = 20;
        dynamic d = 50;
        static void Main(string[] args)
        {
            var testVar = "Abhijit"; //var hold the reference initial type.
           //  testVar = 25; // we canot  re-initilized var variable with different type 

            object testObject = 25;
            testObject = "Abhijit";  // we can redeclare object variable with different type 
            string assign = (string)testObject;
            string assign2 = testObject.ToString();// we need to explicitly type casting for object variable.

            dynamic testDynamic = 10;
            testDynamic = "Abhi";
            string assignd = testDynamic; // for dynamic reference no need explicitly type casting.

            Console.WriteLine(testDynamic);

            dynamic x = 10;
            dynamic y = 20;
            var a = x+y;
            

            Console.ReadLine();
        }
    }
}
