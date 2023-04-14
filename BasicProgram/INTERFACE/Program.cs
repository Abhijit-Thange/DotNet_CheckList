using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERFACE
{
    interface Person
    {
        
       // string Name { get; set;}

        void Details();
    }

    interface i1
    {
        void print1();
    }
    interface i2
    {
        void print2();
    }

    interface i3 :i1,i2
    {
        void print3();
    }

    class Child : i3
    {
        public void print1()
        {
            Console.WriteLine("Interface I1");
        }

        public void print2()
        {
            Console.WriteLine("Interface I2");
        }

        public void print3()
        {
            Console.WriteLine("Interface I3");
        }
    }

    class Student : Person,i1
    {
        public void Details()
        {
            throw new NotImplementedException();
        }

        public void print1()
        {
            throw new NotImplementedException();
        }
    }

    //Explict Interface...

    interface M1
    {
        void Show();
    }
    interface M2
    {
        void Show();
    }

    class ExplicitInterface : M1, M2
    {
        void M1.Show()
        {
            Console.WriteLine("Show Method Interface M1...");
        }

        void M2.Show()
        {
            Console.WriteLine("Show Method Interface M2..");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            child.print1();
            child.print2();
            child.print3();
            
            i3 it=new Child();

            //Two way Of Calling Same Method of Different Interface..
            ExplicitInterface exp=new ExplicitInterface();
            ((M1)exp).Show();
            ((M2)exp).Show();

            //OR
            M1 m1 = new ExplicitInterface();
            m1.Show();

            M2 m2 = new ExplicitInterface();
            m2.Show();

            Console.ReadLine();

        }
    }
}
