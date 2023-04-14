namespace ConstructorOverloading
{
    internal class Program
    {
       public int id;
        string name;
        public Program()
        {
            

        }
        public Program(int id)
        {
            this.id = id;
        }

        public Program(int id,string name)
            : this(id)
        {
            
            //this.id = id;
            this.name = name;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            new Program(5);
            var program = new Program(10,"Jhon");
           // program.id = 3;
            Console.WriteLine("Hi {0} Your id is {1}",program.name,program.id);
        }

    }
}