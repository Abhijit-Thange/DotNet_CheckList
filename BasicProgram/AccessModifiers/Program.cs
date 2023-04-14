using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Person
    {
        private DateTime _birthdate;

        public void SetBirtdate(DateTime birthdate)
        {
           _birthdate = birthdate;
        }
        public DateTime GetBirthdate()
        {
            return _birthdate;
        }
    }
   
    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.SetBirtdate(new DateTime(1998,02,06));
            Console.WriteLine(person.GetBirthdate());
            Console.ReadLine();
        }
    }
}
