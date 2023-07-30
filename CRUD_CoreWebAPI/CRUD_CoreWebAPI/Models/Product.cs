using System.ComponentModel.DataAnnotations;

namespace CRUD_CoreWebAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Double Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime MfgDate { get; set; }
        public int CategoryId { get; set; }

        public string CreatedBy { get; set; }
    }
}
