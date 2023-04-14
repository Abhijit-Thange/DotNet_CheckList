using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fields
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customers cs=new Customers(1);
            cs.orders.Add(new Orders());
            cs.orders.Add(new Orders());

            cs.Promot();

            Console.WriteLine(cs.orders.Count);
            Console.ReadLine();
        }
    }
}
