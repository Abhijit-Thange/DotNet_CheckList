using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public class Program
    {
        public void first()
        {
            Console.WriteLine("First..");
        }
        public void second()
        {
            Console.WriteLine("Second..");
        }
        static void Main(string[] args)
        {
            Program p = new Program();

           p.Third();
            Console.ReadLine();
        }
    }
}
