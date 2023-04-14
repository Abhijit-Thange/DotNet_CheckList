using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumarable___IEnumarator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();      
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);

            IEnumerable<int> enumerable = list; //IEnumerable don't know his current state of cursor
            Range0To5(enumerable);
            foreach (int i in enumerable)
            {
              //  Console.WriteLine(i);
            }

            IEnumerator<int> enumerator = enumerable.GetEnumerator(); //Ienumartor know his current state of cursor
           // RatorRange0To5(enumerator);
            while (enumerator.MoveNext())
            { 
               // Console.WriteLine(enumerator.Current);
            }

            Console.ReadLine();
        }

        public static void Range0To5(IEnumerable<int> enumerable)
        {
            Console.WriteLine("IEnumerable Output Less Than 5.....");
            foreach (int i in enumerable)
            {
                Console.WriteLine(i);
                if(i>5)
                {
                    Range5toAbove(enumerable);
                }
            }              
        }

        public static void Range5toAbove(IEnumerable<int> enumerable)
        {
            Console.WriteLine("IEnumerable Output Above 5.....");  
            foreach (int i in enumerable)
            {
                Console.WriteLine(i);
            }
        }

        static void RatorRange0To5(IEnumerator<int> enumerable)
        {
            Console.WriteLine("IEnumerator Output Less Than 5.....");
            while (enumerable.MoveNext())
            {
                Console.WriteLine(enumerable.Current);
                if (enumerable.Current > 5)
                {
                    RatorRange5ToAbove(enumerable);
                }
            }
        }

        static void RatorRange5ToAbove(IEnumerator<int> enumerable)
        {
            Console.WriteLine("IEnumerator Output More Than 5.....");
            while (enumerable.MoveNext())
            {
                Console.WriteLine(enumerable.Current);
            }
        }

    }
}
