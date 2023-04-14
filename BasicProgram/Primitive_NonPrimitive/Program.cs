using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primitive_NonPrimitive
{

    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            byte pb = 10;
            Byte np = 10;


            short s = 10;

            int ps = 20;
         
            float fl = 20.30f;
           
            double dou = 30.444;
            Double dl = 50.34;

            long lo = 345678;

            decimal de = 34.56m;

            char ch='a';
            Char c = ch;

            bool boolean = false;
            Boolean boolean2=false;

            sbyte sb = 10;
            
        uint ui = 10;
        ulong ul=20;
            ushort us = 10;
            
            string str1 = "123Pq";
            int k;
            int n=int.Parse(str1); //it throws an error if conversion fails
            bool m=int.TryParse(str1, out k);// this is not throws an error if conversion fais because its return type id boolean.

            Console.WriteLine(n);

            //Reference Type
            string ss = "abc";
              
            //class
            //all arrays
            //object
            //Delegates
            //Interface
            
        }
    }
}
