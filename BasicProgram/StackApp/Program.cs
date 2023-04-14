using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Push(40);
            stack.Push(90);

            stack.Pop();

            Console.ReadLine();

        }
    }

    class Stack
    {
        public List<object> list=new List<object>();

        public void Push(int x) 
        { 
            list.Add(x);
        }

        public void Pop()
        {
            if (list.Count == 0)
                Console.WriteLine("Stack is Empty...");
            else
            {
                Console.WriteLine("Pop Element :"+list[list.Count-1]);
                list.RemoveAt(list.Count - 1);
            }           
        }
    }

}
