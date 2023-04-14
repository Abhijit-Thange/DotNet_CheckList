using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamKeyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p=new Program();
            p.Addition(1, 2, 3, 4, 7, 9);
            Console.ReadLine();
        }

        
        public void Addition( params int[] values )
        {
            foreach( int i in values )
            {
                Console.WriteLine(i);
            }          
        }
        
    }
}
