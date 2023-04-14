using System.Security.Cryptography.X509Certificates;

namespace ConstrudtorUse
{
    internal class Program
    {
        int id;
        string name;
        public Program(int id, string name)
        {
            this.id = id;
            this.name = name;
            Console.WriteLine(id + " "+name );
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

             Program p1 = new Program(2, "Nimap");
            
        }

    }
}