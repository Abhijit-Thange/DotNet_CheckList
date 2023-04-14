using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticKeyword
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static string Description { get; set; }


        public static void Display()
        {
            Console.WriteLine(Description);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student.Description = "abcdef";
            Student.Display();
            Console.ReadLine();

        }
    }
}
