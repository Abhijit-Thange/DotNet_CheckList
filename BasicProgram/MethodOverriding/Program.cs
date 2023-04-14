using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverriding
{
    class Parent
    {
        public  virtual void Print()
        {
            Console.WriteLine("Parent Class....");
        }
    }
    class Child:Parent
    {
        public override void Print()
        {
           //  base.Print();
            Console.WriteLine("Child Class....");
        }
    }

    class ThirdChild:Child
    {
        public new void Print()
        {
            Console.WriteLine("Third Child Class.....");
        }
    }
    internal class Program
    {        
        static void Main(string[] args)
        {
            Parent p=new ThirdChild();
            p.Print();
            Console.ReadLine();
        }
    }
}
