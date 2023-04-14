using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Templeted_HTML_Helper.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name="Enter Name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Time)]
        public DateTime BirthTime { get; set; }
    }
}