using Microsoft.EntityFrameworkCore;

namespace CRUD_CoreWebAPI.Models
{
    [Keyless]
    public class Report
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CreatedBy { get; set; }

        public Report() { }
    }
}
