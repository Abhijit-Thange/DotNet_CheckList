using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_Ref
{
    public class Program
    {
        static void Main(string[] args)
        {

            int n=10 ; //ref parameter is must be initialized at time of declaration.
            int i ;     //out parameter is not mandotary to initialized at the time od declaration


          RefOut(ref n, out i);     
            Console.WriteLine(n + "  " + i);
            Console.ReadLine();


        }

    public static void RefOut(ref int x, out int y)
    {
            y = 0; // 
            y = y + 20;    // before return the function out parameter must be initialized
          x += 1;         //ref parameter is not compulsary to intialize before returning.
        Console.WriteLine(x);
    }
            



    }
}
