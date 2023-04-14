using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list=new List<int>() { 1,2,4,6,9,7,11,2,2,21,24,2 ,76};
            var res=new List<int>();

            // list.Addition(11);
            // list.AdditionRange(new int[5] { 21, 2, 2, 24, 2 });
            //  Console.WriteLine(list.IndexOf(2)+ "  "+list.LastIndexOf(2));
            Console.WriteLine(list.Count);



            for (int i=0;i <=list.Count()-1; i++)
            {
                Console.WriteLine(list[i]);
                if (list[i] == 2)
                {
                    list.Remove(list[i]);
                }
            }

            Console.WriteLine();
            //list.Clear();

            foreach(int i in list)
            {
                Console.Write(i+" ");
                //list.Addition(55);    //we can't Modify Collection Inside foreach loop
            }
            Console.ReadLine();
        }
    }
}
