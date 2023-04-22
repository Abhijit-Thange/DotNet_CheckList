using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Operations_Product_and_Category.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}