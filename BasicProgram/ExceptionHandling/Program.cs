using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 7, 5, 9, 10 };

          /*  try
            {
                Console.WriteLine(arr[10]);
            }
            catch(Exception e) 
            {
                Console.WriteLine(e);
            }
            finally 
            {

                Console.ReadLine();
            }*/

            Age(17);
            Console.ReadLine() ;

        }

        static void Age(int age)
        {
            if(age<18)
            {
                throw new Arithmetic("You are less than 18");
            }
            else
            {
                Console.WriteLine("You are old...");
            }
        }
    }

    class Arithmatic
    {
        public Arithmatic(string s)
        {
            Console.WriteLine(s);
        }
    }
}
