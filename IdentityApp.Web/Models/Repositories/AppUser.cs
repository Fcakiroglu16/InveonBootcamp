using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Web.Models.Repositories
{
    public enum UserType : byte
    {
        Normal = 1,
        Super = 2
    }

    public class AppUser : IdentityUser<Guid>
    {
        public string? City { get; set; }

        public UserType UserType { get; set; }

        public UserFeature? UserFeature { get; set; }
    }
}