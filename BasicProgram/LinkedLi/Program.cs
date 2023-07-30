using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  LinkedListNode<int> list = new LinkedListNode<int>();
           // 4, 5, 6, 7, 8, 9, 11, 12, 13, 6, 7, 8, 9

            LinkedList<int> li = new LinkedList<int>();

            li.AddLast(4);
            li.AddLast(5);
            li.AddLast(6);
            li.AddLast(7);
            li.AddLast(8);
            li.AddLast(9);

            LinkedList<int> li2 = new LinkedList<int>();
            li2.AddLast(11);
            li2.AddLast(12);
            li2.AddLast(13);
            li2.AddLast(6);
            li2.AddLast(7);
            li2.AddLast(8);
            li2.AddLast(9);

            LinkedList<int> ints = FindIntersection(li,li2);

            foreach (int j in ints)
            {
                Console.WriteLine(j);
            }
            Console.ReadLine();
        }

        private static LinkedList<int> FindIntersection(LinkedList<int> li, LinkedList<int> li2)
        {
          // HashSet<int> result = new HashSet<int>(li);
            LinkedList<int> inter = new LinkedList<int>();

            foreach(int i in li)
            {
               foreach(int j in li2)
                    if(i==j)
                    inter.AddLast(i);
            }
            return inter;
        }
    }
}
