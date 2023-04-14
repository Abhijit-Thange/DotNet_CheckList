using System.Collections.Generic;

namespace Fields
{
    public class Customers
    {
        public int id;
        public string name;
        public readonly List<Orders> orders = new List<Orders>();

        public Customers(int id) { 
            this.id = id;   
        }

        public Customers(int id, string name)
            :this(id)
        {
            this.name = name;
        }

        public void Promot()
        {
           // orders=new List<Orders>();
        }
    }
}
