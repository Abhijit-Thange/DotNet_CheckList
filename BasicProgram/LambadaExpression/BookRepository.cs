using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambadaExpression
{
    public class BookRepository
    {

        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() { Title = "Book 1", Price = 20 },
                new Book() { Title = "Title", Price = 5 },
                new Book() { Title = "Description", Price = 20 }
            };
        }
    }
}
