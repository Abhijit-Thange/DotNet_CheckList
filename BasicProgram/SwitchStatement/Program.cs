using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace SwitchStatement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a NUmber" );
            int i= Convert.ToInt32(Console.ReadLine());
           // int i = Convert.ToInt32(n);
            Console.WriteLine("External ", i);

            switch(i)
            {
                case 1: Console.WriteLine(value());
                    break;

                    case 2: Console.WriteLine(i);   Console.WriteLine(i); break;

                    case 3: Console.WriteLine(i);  break;


            }
            Console.ReadKey();
           // Console.ReadLine();
        }

        public static int value()
        {
            return 10;
        }
    }
}
