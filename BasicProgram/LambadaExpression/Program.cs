using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambadaExpression
{
    internal class Program
    {
        public delegate int MyDelegate(int x);
        public delegate int MyDelegate2(int x,int y);
        static void Main(string[] args)
        {
            //Expression Lambda Expression
            MyDelegate obj = (a) => a * a;
           int i= obj.Invoke(7);
            Console.WriteLine(i);

            MyDelegate2 obj2 = (a, b) => a + b;
           // Console.WriteLine(obj2.Invoke(5, 10));

            //Statement Lambda Expression
            MyDelegate obj3 = (a) =>
            {
                a = a * a;
                return a;
            };

           // Console.WriteLine(obj3(6));
           // Console.WriteLine(number(10));

            BookRepository bookRepository = new BookRepository();   

            var book= bookRepository.GetBooks();
            var result=book.FindAll(b => b.Price>10);
            
            foreach(var books in result)
            {
                Console.WriteLine(books.Title+"  "+books.Price);
            }

            Console.ReadLine();
        }

        private static string number(int v)
        {
            Func<int, string> i = number => number+"jit";
            return i(v);

        }
    }
}
