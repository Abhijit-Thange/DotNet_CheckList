using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Program
    {
        public delegate void HelloFunctionDelegate(string message);
        static void Main(string[] args)
        {
            HelloFunctionDelegate dl=new HelloFunctionDelegate(Hello);
            dl("Delegate is Pointing to a Function... It is type safe..");

            Console.ReadLine(); 
        }

        public static void Hello(string message)
        {
            Console.WriteLine(message); 
           // return 0;
        }
    }
}
