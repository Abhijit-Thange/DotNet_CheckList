using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 2,5,8,4,9,6,7};
           //  Thread o1 = new Thread(RunsMillionIteration);
           //  o1.Start();
           // Parallel.For(0, 1000000, x => RunsMillionIteration()); //TPL
            Parallel.ForEach(list, x => Console.WriteLine(add(x)) );  //ForEach used for iterating the collection
            Parallel.Invoke();
           
            Console.Read();
        }

        public static void RunsMillionIteration()
        {
            string s = "";
            for(int i=0; i < 10000000; i++)
            {
                s = s + "s";
            }
        }

        static int add(int x)
        {
            return x * x;
        }
    }
}
