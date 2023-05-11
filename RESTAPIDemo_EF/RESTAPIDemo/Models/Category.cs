using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTAPIDemo.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }

        public Category() { }

    }
}