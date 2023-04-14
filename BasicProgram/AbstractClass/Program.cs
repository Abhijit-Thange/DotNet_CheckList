using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Simple
    {

    }
    abstract class Super
    {
        public abstract void super();
        
    }
   abstract class Person:Super
    {
        public abstract uint Id { get; set; }
        public abstract string Name { get;set; }
        public abstract void Run();
        public abstract void Test();
    }

    class Student : Person
    {
        public uint StudentId;
        public string StudentName;
        public override uint Id 
        { get
            {
                return this.StudentId;
            }
            set { this.StudentId = value; }
                
         }
        public override string Name
        {
            get
            {
                return this.StudentName;
            }
            set
            {
                this.StudentName = value;   
            }
        }

        public override void Run() { }

        public override void Test() { }

        public override void super()
        {
            throw new NotImplementedException();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Id = 1;
            student.Name = "Test";
            Console.WriteLine(student.Name);
            Console.ReadLine();    
        }
    }


}
