using Microsoft.AspNetCore.Identity;

namespace UserWebAPI.Models
{
    public class User : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public User() : base() { }
    }
}
