using Microsoft.AspNetCore.Identity;

namespace CRUD_CoreWebAPI.Models
{
    public class User:IdentityUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
