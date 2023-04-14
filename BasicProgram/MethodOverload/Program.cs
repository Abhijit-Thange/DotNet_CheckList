
namespace MethodOverload
{
    internal class Program
    {
        public void Addition(int a,int b)
        { 
            Console.WriteLine(a + b);
        }

        public void Addition(int a, int b,int c)
        {
            Console.WriteLine(a + b+c);
        }


        public void Addition(int a, double b)
        {
            Console.WriteLine(a + b);
        }

        public void Addition(double a, int b)
        {
            Console.WriteLine(a + b);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int a = 5;
            double b = 4.3;
            Program p=new Program();    
            p.Addition(a,b);

        }
    }
}