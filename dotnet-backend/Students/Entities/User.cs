
namespace Students.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
    }

    public class Role : IdentityRole
    {
        public string Discriminator { get; set; }
    }
}