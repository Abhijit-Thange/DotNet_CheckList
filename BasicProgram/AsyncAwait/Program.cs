using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test();
            Display1();
            Display2();
            Display3();

            Console.WriteLine("Main Thread....");
            Console.ReadLine();
        }

        public static async void Test() 
        {
            Console.WriteLine("Test Start...");
           await Task.Run(new Action(Check));
            Console.WriteLine("Test End......");
        }

        public static void Check() 
        {
            Thread.Sleep(2000);      
        }

        public async static void Display1()
        {
           await Task.Run(()=>{
                Console.WriteLine("Display1 Start....");
                Thread.Sleep(2000);
                Console.WriteLine("Display1 End....");
            });           
        }
        public async static void Display2()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Display2 Start....");
                Thread.Sleep(6000);
                Console.WriteLine("Display2 End....");
            });          
        }
        public async static void Display3()
        {
            await Task.Run(() => {
                Console.WriteLine("Display3 Start....");
                Thread.Sleep(1000);
                Console.WriteLine("Display3 End....");
            });
           
        }
    }
}
