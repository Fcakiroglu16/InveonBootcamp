using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityApp.Web.Models.Repositories
{
    public class UserFeature
    {
        public Guid UserId { get; set; }
        public string Gender { get; set; } = default!;

        public AppUser AppUser { get; set; } = default!;
    }
}