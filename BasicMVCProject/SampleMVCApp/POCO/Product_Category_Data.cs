using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMVCApp.POCO
{
    public class Product_Category_Data
    {
        public Product_Category_Data() { }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

    }
}